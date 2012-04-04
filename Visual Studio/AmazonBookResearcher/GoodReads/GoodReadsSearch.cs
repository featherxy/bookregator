using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace BookResearcher.GoodReads
{
    class GoodReadsSearch : Search
    {
        public static string Key = "bd5w8e0FtI9UP2Ba2YPJVQ";
        //public static string Secret = "jbeQafkMetAG6LY2BOcNV9pYrhDhaiTzPXGM6kTUk";

        public String[] Requests { get; set; }
        public String[] Elements { get; set; }
        public String[] TableHeader { get; set; }
        private List<String> tildeList
        {
            get
            {
                List<String> temp = new List<string>();
                temp.AddRange(Elements.Select(t => "~"));
                return temp;
            }
        }
        
        public GoodReadsSearch(String[] requests, String[] elements, String[] tableHeader)
        {
            Requests = requests;
            Elements = elements;
            TableHeader = tableHeader;

            TotalRequests = Requests.Length;
            CurrentRequest = 0;
        }

        public override CsvTable CreateTable(System.ComponentModel.BackgroundWorker worker)
        {
            TotalRequests = Requests.Length;
            CurrentRequest = 0;
            worker.ReportProgress(CurrentRequest);

            //Create table and add header
            CsvTable table = new CsvTable();
            List<String> temp = new List<string> { "Request" };
            temp.AddRange(TableHeader);
            table.Add(new CsvRow(temp));
            temp.Clear();

            for (int index = 0; index < Requests.Length; index++)
            {
                //Caches intial time
                DateTime intialTime = DateTime.Now;

                String request = Requests[index];
                List<String> row = new List<string> { request };

                if (request.Equals("~"))
                    temp = tildeList;
                else
                {
                    temp = FetchInformation(request, out Error);

                    if (Error != null && temp == null)
                        return table;
                }

                //Ensures the operation takes at least one second by sleeping
                //the thread for any remaining time. GoodReads api requirement.
                TimeSpan elapsedTime = DateTime.Now - intialTime;
                if(elapsedTime.TotalSeconds < 1)
                    Thread.Sleep(1000 - (int)elapsedTime.TotalMilliseconds);
                
                row.AddRange(temp);
                table.Add(new CsvRow(row));
                CurrentRequest = index + 1;
                worker.ReportProgress(CurrentRequest);
            }
            Error = null;
            return table;
        }

        private List<String> FetchInformation(String request, out String error)
        {
            String url = GetXmlUrl(request);
            XmlDocument doc = new XmlDocument();
            error = null;

            //Check for known errors
            try
            {
                bool nullReference = true;
                doc.Load(url);

                XmlNode node = doc.GetElementsByTagName("query")[0];
                if(!node.InnerText.Equals(""))
                {
                    node = doc.GetElementsByTagName("total-results")[0];
                    int requestsCount = int.Parse(node.InnerText);
                    if(requestsCount > 0)
                    {
                        nullReference = false;
                    }
                }

                if (nullReference)
                    throw new Exception("Doc Failure");
            }
            catch (Exception)
            {
                //error = e.Message;
                return tildeList;
            }

            List<String> information = new List<string>();
            foreach(String element in Elements)
            {
                XmlNodeList nodeList = doc.GetElementsByTagName(element);
                if(nodeList.Count > 0)
                {
                    XmlNode node = nodeList[0];
                    if(!node.InnerText.Equals(""))
                    {
                        information.Add(node.InnerText);
                        continue;
                    }
                }

                information.Add("~");
            }

            return information;
        }

        private String GetXmlUrl(String request)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("http://www.goodreads.com/search/index.xml?key=")
                .Append(Key)
                .Append("&q=")
                .Append(ParseRequest(request));
            return stringBuilder.ToString();
        }

        private static String ParseRequest(String request)
        {
            String[] parsedRequest = request.Split(' ');
            StringBuilder stringBuilder = new StringBuilder();

            for(int i=0; i < parsedRequest.Length; i++)
            {
                stringBuilder.Append(parsedRequest[i]);
                if (i + 1 < parsedRequest.Length)
                    stringBuilder.Append("+");
            }

            return stringBuilder.ToString();
        }

        public static void SetDefaultAccountDetails()
        {
            Key = "bd5w8e0FtI9UP2Ba2YPJVQ";
            //Secret = "jbeQafkMetAG6LY2BOcNV9pYrhDhaiTzPXGM6kTUk";
        }
    }
}

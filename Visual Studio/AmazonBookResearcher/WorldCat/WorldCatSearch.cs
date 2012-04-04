using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace BookResearcher.WorldCat
{
    public class WorldCatSearch : Search
    {
        public const String BaseUrl = "http://xisbn.worldcat.org/webservices/xid/isbn/";
        public const String SearchSpecification = "?method=getEditions&format=xml&fl=";
        private String[] ISBNs;
        private String[] metaData;
        private List<String> tildeList
        {
            get
            {
                List<String> temp = new List<string>();
                temp.AddRange(metaData.Select(t => "~"));
                if (calculateOldestYear)
                    temp.Add("~");
                return temp;
            }
        }

        //Calculated fields
        private bool calculateOldestYear;

        public WorldCatSearch(String[] ISBNs, List<String> elements)
        {
            this.ISBNs = ISBNs;

            foreach (string metaDat in elements.Where(metaDat => metaDat.Equals("oldestYear")))
                calculateOldestYear = true;
            
            if (calculateOldestYear && !elements.Contains("year"))
                elements.Add("year");

            metaData = elements.ToArray();

            TotalRequests = ISBNs.Length;
            CurrentRequest = 0;
        }

        public override CsvTable CreateTable(BackgroundWorker worker)
        {
            TotalRequests = ISBNs.Length;
            CurrentRequest = 0;
            worker.ReportProgress(CurrentRequest);

            //Create table and header
            CsvTable table = new CsvTable();
            List<String> temp = new List<string> {"ISBN"};
            temp.AddRange(metaData);
            if (calculateOldestYear)
                temp.Add("oldestYear");
            table.Add(new CsvRow(temp));
            temp.Clear();

            for (int index = 0; index < ISBNs.Length; index++)
            {
                var isbn = ISBNs[index];
                List<String> row = new List<string> {isbn};

                if (isbn.Equals("~"))
                {
                    temp = tildeList;
                }
                else
                {
                    temp = FetchInformation(isbn, out Error);

                    if (Error != null && temp == null)
                    {
                        return table;
                    }
                }
                
                row.AddRange(temp);
                table.Add(new CsvRow(row));
                CurrentRequest = index + 1;
                worker.ReportProgress(CurrentRequest);
            }
            Error = null;
            return table;
        }

        private List<String> FetchInformation(String isbn, out String error)
        {
            StringBuilder url =
                new StringBuilder().Append(BaseUrl).Append(isbn).Append(SearchSpecification);
            error = null;

            for (int i = 0; i < metaData.Length; i++)
            {
                url.Append(metaData[i]);
                if (i + 1 < metaData.Length)
                    url.Append(",");
            }

            XmlDocument doc = new XmlDocument();
            String statCheck = null;
            try
            {
                bool nullReference = true;
                doc.Load(url.ToString());

                XmlNodeList nodeList = doc.GetElementsByTagName("rsp");
                if(nodeList.Count > 0)
                {
                    XmlAttributeCollection attributes = nodeList[0].Attributes;
                    if(attributes != null && attributes.Count > 0)
                    {
                        XmlAttribute statAttribute = attributes["stat"];
                        if (statAttribute != null)
                        {
                            nullReference = false;
                            statCheck = statAttribute.Value;
                        } 
                    }
                }
                
                if(nullReference)
                    throw new Exception("Doc Failure");
            }
            catch (Exception e)
            {
                error = e.Message;
                return null;
            }

            //Check for throttling and stop
            if (statCheck.Equals("overlimit"))
            {
                error = "Excceded request limit";
                return null;
            }
            //Check for all other errors and return a tildeList
            if(!statCheck.Equals("ok"))
            {
                return tildeList;
            }

            XmlNodeList nodes = doc.GetElementsByTagName("isbn");
            List<String> information = new List<string>();
            foreach (String metaAttribute in metaData)
            {
                if (nodes[0].Attributes != null)
                {
                    XmlAttribute xmlAttribute = nodes[0].Attributes[metaAttribute];
                    if (xmlAttribute != null)
                    {
                        information.Add(xmlAttribute.Value);
                        continue;
                    }
                }
                information.Add("~");
            }

            if (calculateOldestYear)
            {
                List<int> publicationYears = new List<int>();
                foreach(XmlNode node in nodes)
                {
                    if (node.Attributes != null && node.Attributes["year"] != null)
                    {
                        String yearAttribute = node.Attributes["year"].Value;
                        int parsedYear;
                        if(yearAttribute != null && int.TryParse(yearAttribute, out parsedYear))
                        {
                            publicationYears.Add(parsedYear);
                        }
                    }
                }
                if(publicationYears.Count > 0)
                {
                    publicationYears.Sort();
                    information.Add(Convert.ToString(publicationYears[0]));
                }
                else
                {
                    information.Add("~");
                }
            }

            return information;
        }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Xml;
using System.IO;
using BookResearcher;

//TODO
//allow custom Associate id
//allow for manipulation of the search index
//allow manipulation of the year
public class AmazonSearch : Search
{
    public String       AccessKeyId           { get; set; }
    public String       SecretKey             { get; set; }
    public String       AssociateTag          { get; set; }
    public String       Year                  { get; set; }
    public String       SearchIndex           { get; set; }
    public String       ResponseGroup         { get; set; }
    public String[]     Requests              { get; set; }
    public String[]     Elements              { get; set; }
    public String       Service               { get; set; }
    public String       Operation             { get; set; }
    public String       IncludeReviewsSummary { get; set; }
    public String       AwsNamespace          { get; set; }
    public bool         ContainsUrlElement    { get; set; }
    public List<String> Isbns                 { get; set; }
     
    private static readonly String[] urlParseElements = new [] {"AvgCustRank"};
    private const string AccountDetailsFileName = "AmazonDetails.txt";
    public const string DESTINATION = "ecs.amazonaws.com";

    public AmazonSearch()
    {
        Year = AmazonForm.DEFAULT_YEAR;
        IncludeReviewsSummary = AmazonForm.DEFAULT_INCLUDE_REVIEWS_SUMMARY;
        Operation = AmazonForm.DEFAULT_OPERATION;
        Service = AmazonForm.DEFAULT_SERVICE;
        SearchIndex = AmazonForm.DEFAULT_SEARCH_INDEX;
        AwsNamespace = AmazonForm.DEFAULT_AWS_NAMESPACE;
    }

    public AmazonSearch(AmazonSearch search, bool compileIsbns, String[] requests, String[] elements, String responseGroup,
        String year, String includeReviews, String operation, String service, String searchIndex, String awsNamespace) : this()
    {
        Isbns = compileIsbns ? new List<String>() : null;
        ResponseGroup = responseGroup;
        TotalRequests = requests.Length;
        Year = Year;
        SearchIndex = SearchIndex;
        CurrentRequest = 0;
        Requests = requests;
        Elements = elements;
        IncludeReviewsSummary = includeReviews;
        Operation = operation;
        Service = service;
        SearchIndex = searchIndex;
        AwsNamespace = awsNamespace;


        if (search != null)
        {
            SecretKey = search.SecretKey;
            AccessKeyId = search.AccessKeyId;
            AssociateTag = search.AssociateTag;
        }

        if (urlParseElements.Any(elements.Contains))
            ContainsUrlElement = true;
    }

    /// <summary>
    /// Creates a table consisting of specified elements for the passed
    /// in requests
    /// </summary>
    /// <returns>Table of requests and corresponding data elements</returns>
    public override CsvTable CreateTable(BackgroundWorker worker)
    {
        TotalRequests = Requests.Length;
        CurrentRequest = 0;
        worker.ReportProgress(CurrentRequest);
            
        SignedRequestHelper helper = new SignedRequestHelper(this);
        Error = null;

        //Checks for special elements

        //Adds the table header into the first row of the table
        List<String> tempList = new List<String>(Elements); 
        tempList.Insert(0, "Request");
        CsvRow tableHeader = new CsvRow(tempList);
        CsvTable table = new CsvTable(tableHeader);

        for (int index = 0; index < Requests.Length; index++)
        {
            string request = Requests[index];
            String requestString = "&Keywords=" + request;

            //Fetches the elements specified for the current request
            List<String> elementArray = FetchInformation(helper.Sign(requestString), Elements, out Error);


            if (Error != null)
                return table;
                
            //Creates a CsvRow from the fetched information
            CsvRow csvRow = new CsvRow {request};
            csvRow.AddRange(elementArray);

            table.Add(csvRow);
            CurrentRequest = index + 1;
            worker.ReportProgress(CurrentRequest);
        }

        TotalRequests = 0;
        CurrentRequest = 0;
        return table;
    }

    /// <summary>
    /// Fetches the elements from the requestUrl and compiles them into an array
    /// </summary>
    /// <param name="requestUrl">A URL generated from the user entered request token</param>
    /// <param name="elements">Elements of information to be found about requests</param>
    /// <returns>Array of data elements from requestUrl</returns>
    private List<String> FetchInformation(String requestUrl, String[] elements, out String error)
    {
        List<String> information = new List<String>();
        String[] htmlSource = null;
        error = null;
        try
        {
            //Sends, Retreives, and Loads the XML document with the data elements
            //for the current request
            WebRequest request = HttpWebRequest.Create(requestUrl);
            WebResponse response = request.GetResponse();
            XmlDocument doc = new XmlDocument();
            doc.Load(response.GetResponseStream());

            //Downloads and splits the html file if a urlElement is contained
            if(ContainsUrlElement)
            {
                XmlNode titleNode = doc.GetElementsByTagName("URL", AwsNamespace).Item(0);
                if(titleNode != null)
                {
                    using(WebClient webClient = new WebClient())
                    {
                        htmlSource = webClient.DownloadString(titleNode.InnerText).Split('\n');
                    }
                }
            }

            if(Isbns != null)
            {
                XmlNode titleNode = doc.GetElementsByTagName("ISBN", AwsNamespace).Item(0);
                Isbns.Add(titleNode != null ? titleNode.InnerText : "~");
            }

            //Iterates through the desired elements for the current request
            foreach (string t in elements)
            {
                if(t.Equals("AvgCustRank"))
                {
                    if(htmlSource != null)
                    {
                            
                    }
                    else
                        information.Add("~");
                }
                else
                {
                    XmlNode titleNode = doc.GetElementsByTagName(t, AwsNamespace).Item(0);
                    information.Add(titleNode != null ? titleNode.InnerText : "~");
                }
            }
        }
        catch (Exception e)
        {
            String[] unformattedError = e.Message.Split(':');
            error = unformattedError.Length > 1 ? unformattedError[1] : unformattedError[0];
        }
        return information;
    }

    // null == valid
    public static String validateAccountDetails(String accessKeyId, String secretAccessKey, String associateTag)
    {
        //Create dummy search
        AmazonSearch search = new AmazonSearch();
        search.AccessKeyId = accessKeyId;
        search.SecretKey = secretAccessKey;
        search.AssociateTag = associateTag;

        //Set up a generic SignedRequestHelper
        String error;
        SignedRequestHelper helper = new SignedRequestHelper(search);
        String requestString = "Service=AWSECommerceService"
                    + "&Version=2011-08-01"
                    + "&Operation=ItemSearch"
                    + "&IncludeReviewsSummary=false"
                    + "&SearchIndex=All"
                    + "&ResponseGroup=SalesRank"
                    + "&Keywords=test"
                    ;
        List<String> testElements = new List<string> { "SalesRank" };
        search.FetchInformation(helper.Sign(requestString), testElements.ToArray(), out error);

        //Return error if produced
        if (error != null)
        {
            if (error.Equals(" (403) Forbidden."))
                return "Invalid account details.";
            else
                return error;
        }

        return null;
    }

    public void Save()
    {
        using (StreamWriter writer = new StreamWriter(AccountDetailsFileName))
        {
            writer.WriteLine(AccessKeyId);
            writer.WriteLine(SecretKey);
            writer.WriteLine(AssociateTag);
        }
    }

    public String Load()
    {
        try
        {
            using (StreamReader reader = new StreamReader(AccountDetailsFileName))
            {
                AccessKeyId = reader.ReadLine();
                SecretKey = reader.ReadLine();
                AssociateTag = reader.ReadLine();
            }
        }
        catch (Exception e)
        {
            return "Error loading Amazon details from file.";
        }
        return null;
    }
}

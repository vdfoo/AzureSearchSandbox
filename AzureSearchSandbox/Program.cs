using Microsoft.Azure.Search;
using System;
using System.Collections.Generic;

namespace AzureSearchSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchServiceName = "daniel";

            string apiKey = "38E9EC1BBC7F012747BE72FDBECDFB3F";
                        
            SearchServiceClient serviceClientApi = Helper.Initialize(searchServiceName, apiKey);
            ISearchIndexClient indexClientApi = serviceClientApi.Indexes.GetClient(Helper.IndexName);

            Uploader uploader = new Uploader();
            uploader.Upload(indexClientApi);

            Searcher searcher = new Searcher();

            Console.WriteLine("Begin searching Perodua....");
            searcher.SearchDocuments(indexClientApi, "Perodua");
            Console.WriteLine(string.Empty);

            // https://docs.microsoft.com/en-us/rest/api/searchservice/odata-expression-syntax-for-azure-search
            Console.WriteLine("Begin searching Hatchback category....");
            searcher.SearchDocuments(indexClientApi, "*", "Category eq 'Hatchback'");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Begin searching Price more than 100,000....");
            searcher.SearchDocuments(indexClientApi, "*", "Price gt 100000");
            Console.WriteLine(string.Empty);

            Console.WriteLine("Begin searching by Category facet");
            List<string> facets = new List<string>();
            facets.Add("Category");
            searcher.SearchDocuments(indexClientApi, "*", null, facets);

            Console.ReadLine();
        }
    }
}

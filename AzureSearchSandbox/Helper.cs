using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace AzureSearchSandbox
{
    public static class Helper
    {
        public const string IndexName = "carindex";

        public static SearchServiceClient Initialize(string serviceName, string apiKey)
        {
            SearchServiceClient serviceClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));
            DeleteIfIndexExist(serviceClient);
            CreateIndex(serviceClient);

            return serviceClient;
        }

        private static void CreateIndex(SearchServiceClient client)
        {
            // https://docs.microsoft.com/en-us/rest/api/searchservice/create-index
            var indexDefinition = new Index()
            {
                Name = IndexName,
                Fields = new []
                {
                    new Field("Id", DataType.String)                     { IsKey = true},
                    new Field("Name", DataType.String)                  { IsSearchable = true, IsFilterable = true},
                    new Field("Price", DataType.Double)                 { IsSortable = true, IsFilterable = true },
                    new Field("Category", DataType.String)              { IsFilterable = true, IsFacetable = true },
                    new Field("LaunchDate", DataType.DateTimeOffset)    { IsSortable = true, IsFacetable = true },
                    new Field("SafetyRating", DataType.Int32)           { IsFilterable = true, IsSortable = true },
                }
            };

            client.Indexes.Create(indexDefinition);
        }

        private static void DeleteIfIndexExist(SearchServiceClient client)
        {
            if(client.Indexes.Exists(IndexName))
            {
                client.Indexes.Delete(IndexName);
            }
        }
    }
}

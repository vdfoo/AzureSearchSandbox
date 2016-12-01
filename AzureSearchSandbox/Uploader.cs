using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AzureSearchSandbox
{
    public class Uploader
    {
        private List<Car> PrepareDocuments()
        {
            List<Car> carDocuments = new List<Car>();

            Car c1 = new Car()
            {
                Id = "1",
                Name = "Proton Iriz",
                Category = "Hatchback",
                LaunchDate = new DateTimeOffset(2015, 1, 20, 0, 0, 0, TimeSpan.Zero),
                Price = 55000,
                SafetyRating = 5
            };

            Car c2 = new Car()
            {
                Id = "2",
                Name = "Perodua Myvi",
                Category = "Hatchback",
                LaunchDate = new DateTimeOffset(2004, 6, 15, 0, 0, 0, TimeSpan.Zero),
                Price = 40000,
                SafetyRating = 3
            };

            Car c3 = new Car()
            {
                Id = "3",
                Name = "Perodua Axia",
                Category = "Hatchback",
                LaunchDate = new DateTimeOffset(2014, 12, 25, 0, 0, 0, TimeSpan.Zero),
                Price = 30000,
                SafetyRating = 2
            };

            Car c4 = new Car()
            {
                Id = "4",
                Name = "BMW 320i Sport",
                Category = "Sedan",
                LaunchDate = new DateTimeOffset(2000, 8, 31, 0, 0, 0, TimeSpan.Zero),
                Price = 300000,
                SafetyRating = 4
            };

            carDocuments.Add(c1);
            carDocuments.Add(c2);
            carDocuments.Add(c3);
            carDocuments.Add(c4);

            return carDocuments;
        }

        public void Upload(ISearchIndexClient indexClient)
        {
            try
            {
                var documents = PrepareDocuments();
                var batch = IndexBatch.Upload(documents);
                indexClient.Documents.Index(batch);

                Thread.Sleep(2000);
            }
            catch (IndexBatchException e)
            {
                Console.WriteLine(
                    $"Oops! The following index failed...\n { e.IndexingResults.Where(r => !r.Succeeded).Select(r => r.Key) }");
            }
        }

    }
}

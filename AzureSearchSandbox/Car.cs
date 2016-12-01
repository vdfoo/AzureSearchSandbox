using System;

namespace AzureSearchSandbox
{
    public class Car
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public DateTimeOffset LaunchDate { get; set; }

        public int? SafetyRating { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}\tName: {Name}\tPrice: {Price}\tCategory: {Category}";
        }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionInventory
    {
        public int Id { get; set; }
        public string MaterialId { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime LastUpdated { get; set; }
        public int MinimumLevel { get; set; }
        public int MaximumLevel { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Properties { get; set; }
    }
}
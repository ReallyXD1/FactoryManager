using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class WarehouseLocation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Zone { get; set; }
        public string Aisle { get; set; }
        public string Rack { get; set; }
        public string Level { get; set; }
        public string Bin { get; set; }
        public bool IsActive { get; set; }
        public double Capacity { get; set; }
        public double UsedCapacity { get; set; }
        public string CapacityUnit { get; set; }
        public List<string> AllowedCategories { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public List<int> CurrentItemIds { get; set; }
        public string Status { get; set; }
        public DateTime LastInventoryDate { get; set; }
    }
}

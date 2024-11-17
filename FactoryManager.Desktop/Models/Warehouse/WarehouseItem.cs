using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class WarehouseItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CurrentQuantity { get; set; }
        public int MinimumLevel { get; set; }
        public int MaximumLevel { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal UnitPrice { get; set; }
        public string Location { get; set; }
        public int LocationId { get; set; }
        public DateTime LastRestockDate { get; set; }
        public DateTime LastStockTakeDate { get; set; }
        public List<string> Suppliers { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public byte[] Image { get; set; }
    }
}

using System;

namespace FactoryManager.Desktop.Models
{
    public class WarehouseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal Quantity { get; set; }
        public decimal MinimumQuantity { get; set; }
        public string Unit { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime LastRestockDate { get; set; }
    }
}

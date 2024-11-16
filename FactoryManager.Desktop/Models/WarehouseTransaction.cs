using System;

namespace FactoryManager.Desktop.Models
{
    public class WarehouseTransaction
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal Quantity { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class WarehouseTransaction
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string TransactionType { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string UnitOfMeasure { get; set; }
        public int SourceLocationId { get; set; }
        public int DestinationLocationId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Reference { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string Notes { get; set; }
        public decimal UnitPrice { get; set; }
        public string BatchNumber { get; set; }
    }
}

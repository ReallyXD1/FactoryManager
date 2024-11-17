using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string ProductId { get; set; }
        public int TargetQuantity { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public List<string> AssignedBatches { get; set; }
        public Dictionary<string, object> Requirements { get; set; }
        public string CustomerReference { get; set; }
    }
}

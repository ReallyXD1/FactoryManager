using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionWaste
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public DateTime OccurredAt { get; set; }
        public string LineId { get; set; }
        public string BatchId { get; set; }
        public string Reason { get; set; }
        public Dictionary<string, object> Details { get; set; }
        public decimal EstimatedCost { get; set; }
    }
}

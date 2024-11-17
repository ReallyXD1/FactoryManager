using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionBatch
    {
        public int Id { get; set; }
        public string BatchNumber { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> QualityMetrics { get; set; }
        public List<string> Resources { get; set; }
        public string ProductionLineId { get; set; }
    }
}

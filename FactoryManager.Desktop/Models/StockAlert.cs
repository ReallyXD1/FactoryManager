using System;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class StockAlert
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string AlertType { get; set; }
        public string Severity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsResolved { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public string Resolution { get; set; }
        public int CurrentStock { get; set; }
        public int ThresholdLevel { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public decimal EstimatedImpact { get; set; }
        public string AssignedTo { get; set; }
    }
}

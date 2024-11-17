using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionCost
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public string BatchId { get; set; }
        public Dictionary<string, object> Breakdown { get; set; }
        public string ApprovedBy { get; set; }
        public List<string> Allocations { get; set; }
        public string Status { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class QualityControl
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ProductionOrderId { get; set; }
        public string ProductionOrderNumber { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Inspector { get; set; }
        public List<string> Parameters { get; set; }
        public List<NonConformity> NonConformities { get; set; }
        public string Notes { get; set; }
        public bool IsPassed { get; set; }
    }
}

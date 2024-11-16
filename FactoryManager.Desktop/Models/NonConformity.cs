using System;

namespace FactoryManager.Desktop.Models
{
    public class NonConformity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public string Description { get; set; }
        public string CorrectiveAction { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportedBy { get; set; }
        public bool IsResolved { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string Resolution { get; set; }
    }
}

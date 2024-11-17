using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityControl
    {
        public int Id { get; set; }
        public string ControlNumber { get; set; }
        public DateTime InspectionDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BatchNumber { get; set; }
        public int InspectorId { get; set; }
        public string InspectorName { get; set; }
        public string Status { get; set; }
        public bool IsPassed { get; set; }
        public List<QualityParameter> Parameters { get; set; }
        public string Notes { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public List<NonConformity> NonConformities { get; set; }
        public byte[] AttachedDocuments { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
    }
}

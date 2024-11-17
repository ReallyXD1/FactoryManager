using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionQuality
    {
        public int Id { get; set; }
        public string BatchId { get; set; }
        public DateTime InspectionTime { get; set; }
        public string Inspector { get; set; }
        public Dictionary<string, object> Measurements { get; set; }
        public bool PassedQC { get; set; }
        public List<string> Defects { get; set; }
        public string Resolution { get; set; }
        public Dictionary<string, object> TestResults { get; set; }
        public string Status { get; set; }
    }
}

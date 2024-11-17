using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionProcess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Steps { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
        public List<string> RequiredResources { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> QualityRequirements { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionTooling
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime LastCalibration { get; set; }
        public DateTime NextCalibration { get; set; }
        public string Location { get; set; }
        public Dictionary<string, object> Specifications { get; set; }
        public List<string> AssignedTo { get; set; }
        public int UsageCount { get; set; }
    }
}

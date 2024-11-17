using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionWorkstation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LineId { get; set; }
        public string Type { get; set; }
        public List<string> Capabilities { get; set; }
        public string Status { get; set; }
        public string CurrentOperator { get; set; }
        public Dictionary<string, object> Equipment { get; set; }
        public bool IsOperational { get; set; }
        public DateTime LastMaintenance { get; set; }
    }
}

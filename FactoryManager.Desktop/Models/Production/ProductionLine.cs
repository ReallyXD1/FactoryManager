using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Capacity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<string> AssignedWorkers { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public string Supervisor { get; set; }
        public bool IsActive { get; set; }
    }
}

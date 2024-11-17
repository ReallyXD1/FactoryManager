using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionShift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<string> AssignedWorkers { get; set; }
        public string Supervisor { get; set; }
        public Dictionary<string, object> Targets { get; set; }
        public bool IsActive { get; set; }
        public List<string> ProductionLines { get; set; }
        public string Status { get; set; }
    }
}
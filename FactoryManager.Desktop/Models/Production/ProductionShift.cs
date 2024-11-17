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
        public List<int> OperatorIds { get; set; }
        public List<string> OperatorNames { get; set; }
        public bool IsActive { get; set; }
        public string Supervisor { get; set; }
        public int SupervisorId { get; set; }
        public List<int> ProductionLineIds { get; set; }
        public double TargetEfficiency { get; set; }
        public Dictionary<string, object> ShiftParameters { get; set; }
        public List<ShiftBreak> Breaks { get; set; }
    }
}

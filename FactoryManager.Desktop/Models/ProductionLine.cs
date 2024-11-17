using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Status { get; set; }
        public double Efficiency { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public List<string> Capabilities { get; set; }
        public int CurrentOrderId { get; set; }
        public string CurrentOrderNumber { get; set; }
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public Dictionary<string, double> Parameters { get; set; }
        public MaintenanceSchedule MaintenanceSchedule { get; set; }
    }
}

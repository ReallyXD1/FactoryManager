using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityMonitor
    {
        public int Id { get; set; }
        public string MonitorType { get; set; }
        public string Status { get; set; }
        public DateTime LastCheck { get; set; }
        public Dictionary<string, object> Metrics { get; set; }
        public List<string> AlertTriggers { get; set; }
        public int Priority { get; set; }
        public string ResponsibleTeam { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public bool IsActive { get; set; }
    }
}

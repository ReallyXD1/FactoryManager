using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Frequency { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> Actions { get; set; }
        public DateTime LastExecuted { get; set; }
    }
}

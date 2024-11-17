using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySchedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Frequency { get; set; }
        public DateTime NextExecution { get; set; }
        public DateTime LastExecution { get; set; }
        public bool IsEnabled { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public List<string> Dependencies { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

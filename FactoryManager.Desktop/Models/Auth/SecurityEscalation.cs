using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityEscalation
    {
        public int Id { get; set; }
        public string Trigger { get; set; }
        public int Level { get; set; }
        public List<string> Notifiers { get; set; }
        public Dictionary<string, object> Actions { get; set; }
        public TimeSpan Timeout { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastTriggered { get; set; }
        public string Resolution { get; set; }
        public Dictionary<string, object> Context { get; set; }
    }
}

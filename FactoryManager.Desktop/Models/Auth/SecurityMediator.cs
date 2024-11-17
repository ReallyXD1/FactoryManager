using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityMediator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Handlers { get; set; }
        public Dictionary<string, object> Routes { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Pipeline { get; set; }
        public TimeSpan ProcessingTimeout { get; set; }
        public List<string> SupportedProtocols { get; set; }
        public DateTime LastActivity { get; set; }
        public string Status { get; set; }
    }
}

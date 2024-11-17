using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityInterceptor
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public List<string> Patterns { get; set; }
        public Dictionary<string, object> Actions { get; set; }
        public bool IsEnabled { get; set; }
        public TimeSpan Timeout { get; set; }
        public string Handler { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public DateTime LastExecuted { get; set; }
    }
}

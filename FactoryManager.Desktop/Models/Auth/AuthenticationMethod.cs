using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public List<string> RequiredFields { get; set; }
        public TimeSpan Timeout { get; set; }
        public int MaxAttempts { get; set; }
        public bool RequiresMFA { get; set; }
        public List<string> SupportedDevices { get; set; }
    }
}

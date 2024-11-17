using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public Dictionary<string, string> Configuration { get; set; }
        public int Priority { get; set; }
        public List<string> SupportedMethods { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public string CallbackUrl { get; set; }
        public List<string> AllowedDomains { get; set; }
        public Dictionary<string, string> ClaimMappings { get; set; }
    }
}

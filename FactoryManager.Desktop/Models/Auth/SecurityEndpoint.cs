using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityEndpoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public List<string> RequiredRoles { get; set; }
        public Dictionary<string, object> SecurityHeaders { get; set; }
        public bool RequiresAuthentication { get; set; }
        public int RateLimit { get; set; }
        public TimeSpan Timeout { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

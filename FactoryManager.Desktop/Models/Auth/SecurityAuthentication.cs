using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAuthentication
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string Principal { get; set; }
        public Dictionary<string, object> Credentials { get; set; }
        public DateTime AuthenticatedAt { get; set; }
        public string Provider { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> Factors { get; set; }
        public TimeSpan SessionDuration { get; set; }
        public Dictionary<string, object> Context { get; set; }
    }
}

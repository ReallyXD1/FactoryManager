using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityPrincipal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Roles { get; set; }
        public Dictionary<string, object> Claims { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTime AuthenticatedAt { get; set; }
        public string AuthenticationType { get; set; }
        public List<string> Permissions { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }
}

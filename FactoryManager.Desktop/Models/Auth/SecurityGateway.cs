using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityGateway
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Endpoint { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public bool IsActive { get; set; }
        public List<string> SupportedProtocols { get; set; }
        public Dictionary<string, object> Policies { get; set; }
        public DateTime LastHealthCheck { get; set; }
        public string Status { get; set; }
    }
}

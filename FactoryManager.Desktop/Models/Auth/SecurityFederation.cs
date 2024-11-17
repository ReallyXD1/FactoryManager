using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityFederation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Partners { get; set; }
        public Dictionary<string, object> TrustSettings { get; set; }
        public string Protocol { get; set; }
        public DateTime EstablishedAt { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> AllowedOperations { get; set; }
        public string Status { get; set; }
    }
}

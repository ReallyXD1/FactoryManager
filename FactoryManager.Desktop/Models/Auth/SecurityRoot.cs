using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Authorities { get; set; }
        public Dictionary<string, object> Certificates { get; set; }
        public bool IsValid { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string IssuerName { get; set; }
        public Dictionary<string, object> Extensions { get; set; }
        public int TrustLevel { get; set; }
    }
}

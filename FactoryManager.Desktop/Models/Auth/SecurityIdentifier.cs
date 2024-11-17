using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityIdentifier
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Format { get; set; }
        public DateTime IssuedAt { get; set; }
        public string IssuedBy { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public List<string> AssociatedEntities { get; set; }
        public string Purpose { get; set; }
    }
}

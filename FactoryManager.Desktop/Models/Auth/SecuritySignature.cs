using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySignature
    {
        public int Id { get; set; }
        public string SignatureType { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string Purpose { get; set; }
        public bool IsValid { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Algorithm { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}

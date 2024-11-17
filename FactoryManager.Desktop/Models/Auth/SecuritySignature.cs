using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySignature
    {
        public int Id { get; set; }
        public string Algorithm { get; set; }
        public byte[] Value { get; set; }
        public string SignedBy { get; set; }
        public DateTime SignedAt { get; set; }
        public string Purpose { get; set; }
        public bool IsValid { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string RelatedDocument { get; set; }
        public int Version { get; set; }
    }
}

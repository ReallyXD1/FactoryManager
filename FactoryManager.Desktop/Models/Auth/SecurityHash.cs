using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityHash
    {
        public int Id { get; set; }
        public string Algorithm { get; set; }
        public byte[] Value { get; set; }
        public string Salt { get; set; }
        public int Iterations { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Purpose { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public bool IsVerified { get; set; }
        public string Source { get; set; }
    }
}

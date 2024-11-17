using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityEncryption
    {
        public int Id { get; set; }
        public string Algorithm { get; set; }
        public string KeyId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Purpose { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsActive { get; set; }
        public int Strength { get; set; }
        public List<string> AllowedOperations { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

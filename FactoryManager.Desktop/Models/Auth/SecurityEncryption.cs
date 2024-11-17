using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityEncryption
    {
        public int Id { get; set; }
        public string Algorithm { get; set; }
        public string Mode { get; set; }
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Purpose { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public int KeySize { get; set; }
        public string Provider { get; set; }
    }
}

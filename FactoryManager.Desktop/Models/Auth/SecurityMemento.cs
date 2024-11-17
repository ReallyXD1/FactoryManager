using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityMemento
    {
        public int Id { get; set; }
        public string State { get; set; }
        public DateTime Timestamp { get; set; }
        public string CreatedBy { get; set; }
        public Dictionary<string, object> Snapshot { get; set; }
        public string Description { get; set; }
        public bool IsRestorePoint { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Version { get; set; }
    }
}

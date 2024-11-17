using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityDescriptor
    {
        public int Id { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public Dictionary<string, object> Permissions { get; set; }
        public List<string> Owners { get; set; }
        public List<string> Groups { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool Inherited { get; set; }
        public Dictionary<string, object> Rules { get; set; }
    }
}

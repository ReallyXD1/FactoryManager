using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityContainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Content { get; set; }
        public bool IsSealed { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public List<string> AccessControl { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Status { get; set; }
    }
}

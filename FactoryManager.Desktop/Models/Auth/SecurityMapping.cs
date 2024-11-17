using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityMapping
    {
        public int Id { get; set; }
        public string SourceType { get; set; }
        public string TargetType { get; set; }
        public Dictionary<string, string> Mappings { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public List<string> AppliesTo { get; set; }
        public Dictionary<string, object> Rules { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityLabel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public bool Mandatory { get; set; }
        public int Priority { get; set; }
        public List<string> AppliesTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityClassification
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public List<string> RequiredClearance { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string IssuedBy { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

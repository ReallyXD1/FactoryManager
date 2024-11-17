using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityFilter
    {
        public int Id { get; set; }
        public string FilterType { get; set; }
        public string Pattern { get; set; }
        public string Action { get; set; }
        public int Priority { get; set; }
        public bool IsEnabled { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public List<string> AppliesTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityResolver
    {
        public int Id { get; set; }
        public string ResolverType { get; set; }
        public string Pattern { get; set; }
        public Dictionary<string, object> Resolution { get; set; }
        public int Priority { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> AppliesTo { get; set; }
        public DateTime LastUsed { get; set; }
        public int SuccessCount { get; set; }
        public Dictionary<string, object> Cache { get; set; }
    }
}

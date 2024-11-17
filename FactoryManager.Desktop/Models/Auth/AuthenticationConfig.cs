using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationConfig
    {
        public int Id { get; set; }
        public string ConfigType { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public bool IsEnabled { get; set; }
        public int Priority { get; set; }
        public List<string> AppliesTo { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public Dictionary<string, string> Variables { get; set; }
        public string Environment { get; set; }
    }
}

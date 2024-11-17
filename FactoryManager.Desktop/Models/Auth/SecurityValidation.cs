using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityValidation
    {
        public int Id { get; set; }
        public string ValidationType { get; set; }
        public DateTime Timestamp { get; set; }
        public string Target { get; set; }
        public Dictionary<string, object> ValidationRules { get; set; }
        public bool IsValid { get; set; }
        public List<string> Violations { get; set; }
        public string ValidatedBy { get; set; }
        public Dictionary<string, object> Results { get; set; }
        public TimeSpan ProcessingTime { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityValidation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public List<string> Rules { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsValid { get; set; }
        public DateTime ValidatedAt { get; set; }
        public string ValidatedBy { get; set; }
        public List<string> Errors { get; set; }
        public Dictionary<string, object> Results { get; set; }
    }
}

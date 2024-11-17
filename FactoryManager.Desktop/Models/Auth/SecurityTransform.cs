using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityTransform
    {
        public int Id { get; set; }
        public string TransformType { get; set; }
        public string InputFormat { get; set; }
        public string OutputFormat { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsReversible { get; set; }
        public List<string> SupportedOperations { get; set; }
        public string Algorithm { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
    }
}

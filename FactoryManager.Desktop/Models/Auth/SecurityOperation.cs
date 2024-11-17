using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityOperation
    {
        public int Id { get; set; }
        public string OperationType { get; set; }
        public string Target { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DateTime ExecutedAt { get; set; }
        public string ExecutedBy { get; set; }
        public string Status { get; set; }
        public TimeSpan Duration { get; set; }
        public Dictionary<string, object> Result { get; set; }
        public List<string> AffectedResources { get; set; }
    }
}

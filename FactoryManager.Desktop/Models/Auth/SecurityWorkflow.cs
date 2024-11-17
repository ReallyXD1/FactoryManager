using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityWorkflow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Steps { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public string CurrentStep { get; set; }
        public DateTime StartedAt { get; set; }
        public string InitiatedBy { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Results { get; set; }
    }
}
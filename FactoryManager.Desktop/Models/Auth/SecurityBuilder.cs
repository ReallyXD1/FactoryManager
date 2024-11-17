using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBuilder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Components { get; set; }
        public List<string> BuildSteps { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartedAt { get; set; }
        public string CreatedBy { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public string Status { get; set; }
    }
}

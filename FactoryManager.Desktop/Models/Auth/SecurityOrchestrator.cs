using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityOrchestrator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Workflows { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public string State { get; set; }
        public DateTime LastExecution { get; set; }
        public List<string> Dependencies { get; set; }
        public Dictionary<string, object> Variables { get; set; }
        public bool IsActive { get; set; }
        public TimeSpan ExecutionInterval { get; set; }
    }
}

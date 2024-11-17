using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityWorkflow
    {
        public int Id { get; set; }
        public string WorkflowType { get; set; }
        public string Status { get; set; }
        public List<string> Steps { get; set; }
        public Dictionary<string, object> StepData { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string InitiatedBy { get; set; }
        public List<string> Approvers { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

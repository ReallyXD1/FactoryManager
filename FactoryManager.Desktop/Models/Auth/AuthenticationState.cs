using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationState
    {
        public string StateId { get; set; }
        public int UserId { get; set; }
        public string CurrentStep { get; set; }
        public List<string> CompletedSteps { get; set; }
        public Dictionary<string, object> StepData { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime LastActivityAt { get; set; }
        public bool IsComplete { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}

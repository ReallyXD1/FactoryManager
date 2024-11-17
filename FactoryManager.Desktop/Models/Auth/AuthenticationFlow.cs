using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationFlow
    {
        public string FlowId { get; set; }
        public string FlowType { get; set; }
        public List<string> RequiredSteps { get; set; }
        public Dictionary<string, object> StepConfiguration { get; set; }
        public int TimeoutSeconds { get; set; }
        public bool AllowRetry { get; set; }
        public int MaxRetries { get; set; }
        public List<string> FallbackMethods { get; set; }
        public Dictionary<string, object> ValidationRules { get; set; }
        public bool IsActive { get; set; }
    }
}

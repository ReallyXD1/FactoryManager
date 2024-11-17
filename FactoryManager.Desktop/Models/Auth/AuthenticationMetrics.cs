using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationMetrics
    {
        public DateTime Timestamp { get; set; }
        public int TotalAttempts { get; set; }
        public int SuccessfulAttempts { get; set; }
        public int FailedAttempts { get; set; }
        public Dictionary<string, int> MethodStats { get; set; }
        public Dictionary<string, int> ErrorTypes { get; set; }
        public TimeSpan AverageResponseTime { get; set; }
        public Dictionary<string, object> AdditionalMetrics { get; set; }
        public List<string> ActiveSessions { get; set; }
        public int ConcurrentUsers { get; set; }
    }
}

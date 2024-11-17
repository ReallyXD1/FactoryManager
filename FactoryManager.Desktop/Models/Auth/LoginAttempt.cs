using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class LoginAttempt
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Success { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string FailureReason { get; set; }
        public Dictionary<string, string> AdditionalInfo { get; set; }
        public string Location { get; set; }
        public string DeviceId { get; set; }
        public string AuthMethod { get; set; }
    }
}

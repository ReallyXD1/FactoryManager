using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationChallenge
    {
        public string ChallengeId { get; set; }
        public int UserId { get; set; }
        public string ChallengeType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Status { get; set; }
        public int AttemptsRemaining { get; set; }
        public Dictionary<string, object> ChallengeData { get; set; }
        public string DeviceId { get; set; }
        public string IpAddress { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}

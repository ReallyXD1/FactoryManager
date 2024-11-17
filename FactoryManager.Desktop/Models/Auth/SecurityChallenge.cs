using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityChallenge
    {
        public int Id { get; set; }
        public string ChallengeType { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public int MaxAttempts { get; set; }
        public int AttemptsUsed { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public string ResponseHash { get; set; }
    }
}

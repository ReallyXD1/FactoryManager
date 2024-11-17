using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationVerification
    {
        public string VerificationId { get; set; }
        public int UserId { get; set; }
        public string VerificationType { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public int AttemptCount { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityVerification
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string Subject { get; set; }
        public Dictionary<string, object> Evidence { get; set; }
        public bool IsVerified { get; set; }
        public DateTime VerifiedAt { get; set; }
        public string VerifiedBy { get; set; }
        public int Confidence { get; set; }
        public List<string> Factors { get; set; }
        public string Status { get; set; }
    }
}

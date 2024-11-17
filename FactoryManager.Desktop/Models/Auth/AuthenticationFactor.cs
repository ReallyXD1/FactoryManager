using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationFactor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FactorType { get; set; }
        public string Identifier { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsed { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public int Priority { get; set; }
        public bool IsDefault { get; set; }
        public string Status { get; set; }
    }
}

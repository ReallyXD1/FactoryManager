using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationSettings
    {
        public int MaxLoginAttempts { get; set; }
        public int LockoutDurationMinutes { get; set; }
        public bool RequireTwoFactor { get; set; }
        public int TokenExpirationMinutes { get; set; }
        public bool AllowRememberMe { get; set; }
        public List<string> AllowedAuthMethods { get; set; }
        public Dictionary<string, object> SecurityPolicies { get; set; }
        public int MinPasswordLength { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireSpecialCharacters { get; set; }
        public int PasswordExpirationDays { get; set; }
        public bool EnforcePasswordHistory { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class PasswordPolicy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinLength { get; set; }
        public bool RequireUppercase { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireNumbers { get; set; }
        public bool RequireSpecialCharacters { get; set; }
        public int MaximumAge { get; set; }
        public int HistoryCount { get; set; }
        public int LockoutThreshold { get; set; }
        public TimeSpan LockoutDuration { get; set; }
        public List<string> ProhibitedPasswords { get; set; }
        public bool EnforceOnNextLogin { get; set; }
    }
}

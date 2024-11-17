using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class TwoFactorAuth
    {
        public int UserId { get; set; }
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public string SecretKey { get; set; }
        public DateTime LastVerified { get; set; }
        public List<string> BackupCodes { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public List<TwoFactorDevice> RegisteredDevices { get; set; }
        public string PreferredMethod { get; set; }
        public DateTime LastCodeGenerated { get; set; }
        public int FailedAttempts { get; set; }
    }
}

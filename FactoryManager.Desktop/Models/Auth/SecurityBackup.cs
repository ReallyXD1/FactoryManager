using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBackup
    {
        public int Id { get; set; }
        public string BackupType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Location { get; set; }
        public long Size { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public bool IsEncrypted { get; set; }
        public DateTime? RestorePoint { get; set; }
    }
}

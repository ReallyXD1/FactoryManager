using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityPatch
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public List<string> FixedVulnerabilities { get; set; }
        public DateTime ReleasedAt { get; set; }
        public bool IsInstalled { get; set; }
        public Dictionary<string, object> Changes { get; set; }
        public string Priority { get; set; }
        public TimeSpan InstallationTime { get; set; }
        public List<string> Dependencies { get; set; }
        public string Status { get; set; }
    }
}

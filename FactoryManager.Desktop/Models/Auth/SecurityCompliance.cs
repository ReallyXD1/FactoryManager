using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCompliance
    {
        public int Id { get; set; }
        public string Standard { get; set; }
        public string Requirement { get; set; }
        public bool IsCompliant { get; set; }
        public DateTime AssessedAt { get; set; }
        public string AssessedBy { get; set; }
        public Dictionary<string, object> Evidence { get; set; }
        public List<string> Gaps { get; set; }
        public DateTime NextAssessment { get; set; }
        public string Status { get; set; }
    }
}

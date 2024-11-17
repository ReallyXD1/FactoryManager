using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCompliance
    {
        public int Id { get; set; }
        public string PolicyName { get; set; }
        public string Standard { get; set; }
        public Dictionary<string, object> Requirements { get; set; }
        public DateTime AssessmentDate { get; set; }
        public bool IsCompliant { get; set; }
        public List<string> Findings { get; set; }
        public string AssessedBy { get; set; }
        public DateTime NextReviewDate { get; set; }
        public Dictionary<string, object> Evidence { get; set; }
    }
}

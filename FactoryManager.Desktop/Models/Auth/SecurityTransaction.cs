using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public List<string> Operations { get; set; }
        public string InitiatedBy { get; set; }
        public bool RequiresApproval { get; set; }
        public Dictionary<string, object> Results { get; set; }
    }
}

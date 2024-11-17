using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Resource { get; set; }
        public string Action { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public string RequestedBy { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; }
        public List<string> Approvers { get; set; }
        public Dictionary<string, object> Response { get; set; }
    }
}

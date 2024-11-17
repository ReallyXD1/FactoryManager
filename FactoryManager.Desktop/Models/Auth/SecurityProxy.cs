using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityInvoker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Commands { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public TimeSpan Timeout { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Results { get; set; }
    }
}

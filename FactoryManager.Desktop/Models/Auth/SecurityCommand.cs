using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool IsExecuted { get; set; }
        public DateTime? ExecutedAt { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Result { get; set; }
    }
}

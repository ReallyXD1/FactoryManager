using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityChain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Handlers { get; set; }
        public int CurrentPosition { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string Status { get; set; }
        public List<string> Results { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityRemediation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public List<string> Steps { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AssignedTo { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Results { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityRisk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public double Probability { get; set; }
        public double Impact { get; set; }
        public Dictionary<string, object> Mitigation { get; set; }
        public string Owner { get; set; }
        public DateTime IdentifiedAt { get; set; }
        public string Status { get; set; }
    }
}

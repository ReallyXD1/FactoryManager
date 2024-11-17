using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationScope
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Permissions { get; set; }
        public List<string> Resources { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public TimeSpan? ValidityPeriod { get; set; }
    }
}

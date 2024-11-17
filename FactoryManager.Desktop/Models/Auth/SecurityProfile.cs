using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public List<string> RequiredRoles { get; set; }
        public List<string> AllowedActions { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Priority { get; set; }
        public List<string> ApplicableEnvironments { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public List<string> AllowedUsers { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public List<string> Resources { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
    }
}

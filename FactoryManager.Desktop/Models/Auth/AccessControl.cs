using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AccessControl
    {
        public int Id { get; set; }
        public string ResourceId { get; set; }
        public string ResourceType { get; set; }
        public List<string> AllowedRoles { get; set; }
        public List<string> AllowedUsers { get; set; }
        public Dictionary<string, List<string>> Permissions { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationResource
    {
        public int Id { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public List<string> RequiredPermissions { get; set; }
        public List<string> AllowedRoles { get; set; }
        public Dictionary<string, object> AccessPolicies { get; set; }
        public bool IsPublic { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

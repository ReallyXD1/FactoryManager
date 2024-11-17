using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationPolicy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> RequiredRoles { get; set; }
        public List<string> RequiredPermissions { get; set; }
        public Dictionary<string, object> Requirements { get; set; }
        public bool IsEnabled { get; set; }
        public string ResourceType { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Claims { get; set; }
        public List<string> AllowedIpRanges { get; set; }
        public TimeSpan? ValidityPeriod { get; set; }
    }
}

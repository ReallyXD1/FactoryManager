using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationAssignment
    {
        public int Id { get; set; }
        public int PrincipalId { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public List<string> Permissions { get; set; }
        public DateTime AssignedAt { get; set; }
        public string AssignedBy { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public Dictionary<string, object> Conditions { get; set; }
        public bool IsActive { get; set; }
    }
}

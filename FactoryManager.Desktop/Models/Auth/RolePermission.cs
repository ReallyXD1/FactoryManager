using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public DateTime AssignedAt { get; set; }
        public int AssignedBy { get; set; }
        public bool IsActive { get; set; }
        public string Scope { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Notes { get; set; }
        public List<string> Conditions { get; set; }
    }
}

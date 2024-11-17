using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Permissions { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public int LastModifiedBy { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> AllowedDepartments { get; set; }
        public bool IsSystem { get; set; }
    }
}

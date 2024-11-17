using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> UserIds { get; set; }
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> Permissions { get; set; }
    }
}

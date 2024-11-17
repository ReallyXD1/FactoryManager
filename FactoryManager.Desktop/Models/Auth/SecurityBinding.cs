using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBinding
    {
        public int Id { get; set; }
        public string SourceId { get; set; }
        public string TargetId { get; set; }
        public string BindingType { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public List<string> Permissions { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}

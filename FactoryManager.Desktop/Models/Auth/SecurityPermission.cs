using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityPermission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resource { get; set; }
        public string Action { get; set; }
        public bool IsGranted { get; set; }
        public List<string> Conditions { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityConstraintSet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Constraints { get; set; }
        public string Operator { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public List<string> AppliesTo { get; set; }
    }
}

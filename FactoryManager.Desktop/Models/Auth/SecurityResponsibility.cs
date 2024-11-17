using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityResponsibility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Duties { get; set; }
        public Dictionary<string, object> Requirements { get; set; }
        public string AssignedTo { get; set; }
        public DateTime AssignedAt { get; set; }
        public bool IsActive { get; set; }
        public List<string> Dependencies { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBoundary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> AllowedSources { get; set; }
        public List<string> AllowedDestinations { get; set; }
        public Dictionary<string, object> Rules { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public DateTime LastUpdated { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
    }
}

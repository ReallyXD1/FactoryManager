using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityLayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public List<string> Components { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
        public List<string> DependentLayers { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
    }
}

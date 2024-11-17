using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCompositor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Components { get; set; }
        public Dictionary<string, object> Layout { get; set; }
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public int Priority { get; set; }
    }
}

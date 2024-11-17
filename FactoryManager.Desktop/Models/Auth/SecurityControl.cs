using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityControl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public Dictionary<string, object> Implementation { get; set; }
        public bool IsEnabled { get; set; }
        public int Strength { get; set; }
        public DateTime LastReview { get; set; }
        public List<string> Dependencies { get; set; }
        public string Effectiveness { get; set; }
    }
}

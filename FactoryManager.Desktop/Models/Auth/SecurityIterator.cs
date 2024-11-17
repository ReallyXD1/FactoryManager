using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityIterator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Collection { get; set; }
        public int Position { get; set; }
        public List<string> Filters { get; set; }
        public bool HasNext { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public Dictionary<string, object> State { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public object Value { get; set; }
        public bool IsRequired { get; set; }
        public string Category { get; set; }
        public Dictionary<string, object> Validation { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Source { get; set; }
        public bool IsMultiValued { get; set; }
    }
}

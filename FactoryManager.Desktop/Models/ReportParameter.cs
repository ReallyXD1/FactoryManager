using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportParameter
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsRequired { get; set; }
        public object DefaultValue { get; set; }
        public List<object> PossibleValues { get; set; }
        public string ValidationRule { get; set; }
        public string DependsOn { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Format { get; set; }
        public object MinValue { get; set; }
        public object MaxValue { get; set; }
    }
}

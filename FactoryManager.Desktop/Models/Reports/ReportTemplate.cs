using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<ReportParameter> Parameters { get; set; }
        public string TemplateFile { get; set; }
        public List<string> SupportedFormats { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModified { get; set; }
        public int Version { get; set; }
        public Dictionary<string, string> DefaultValues { get; set; }
        public List<string> RequiredPermissions { get; set; }
    }
}

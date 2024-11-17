using System;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class InventoryReportOptions
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> LocationIds { get; set; }
        public bool IncludeLowStock { get; set; }
        public bool IncludeMovements { get; set; }
        public string ReportFormat { get; set; }
        public bool IncludeImages { get; set; }
        public string GroupBy { get; set; }
        public List<string> Columns { get; set; }
        public string SortBy { get; set; }
        public bool SortAscending { get; set; }
    }
}

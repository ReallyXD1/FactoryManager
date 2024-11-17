using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionEvent
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string Severity { get; set; }
        public bool RequiresAction { get; set; }
        public string Resolution { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public int? ResolvedByUserId { get; set; }
    }
}

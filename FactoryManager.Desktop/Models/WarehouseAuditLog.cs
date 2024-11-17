using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class WarehouseAuditLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string EntityType { get; set; }
        public int EntityId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> OldValues { get; set; }
        public Dictionary<string, string> NewValues { get; set; }
        public string IpAddress { get; set; }
        public string Notes { get; set; }
        public bool IsSystemGenerated { get; set; }
    }
}

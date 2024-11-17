using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int ProductionLineId { get; set; }
        public string ProductionLineName { get; set; }
        public double Progress { get; set; }
        public string Priority { get; set; }
        public List<ProductionEvent> Events { get; set; }
        public string Notes { get; set; }
        public int AssignedOperatorId { get; set; }
        public string AssignedOperatorName { get; set; }
    }
}

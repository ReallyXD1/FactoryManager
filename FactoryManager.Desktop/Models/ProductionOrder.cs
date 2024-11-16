using System;

namespace FactoryManager.Desktop.Models
{
    public class ProductionOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductionLineId { get; set; }
        public string ProductionLineName { get; set; }
        public int Quantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public double Progress { get; set; }
    }
}

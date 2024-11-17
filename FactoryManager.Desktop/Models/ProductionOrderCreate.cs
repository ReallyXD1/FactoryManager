using System;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionOrderCreate
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public int ProductionLineId { get; set; }
        public string Priority { get; set; }
        public string Notes { get; set; }
        public int AssignedOperatorId { get; set; }
    }
}

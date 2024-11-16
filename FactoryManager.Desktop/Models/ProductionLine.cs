using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class ProductionLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public double Efficiency { get; set; }
        public int CurrentOrderId { get; set; }
        public List<string> SupportedProducts { get; set; }
        public string Status { get; set; }
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
    }
}

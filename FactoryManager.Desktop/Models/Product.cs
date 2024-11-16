namespace FactoryManager.Desktop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }
        public string Unit { get; set; }
        public bool IsActive { get; set; }
        public List<string> RequiredMaterials { get; set; }
        public Dictionary<string, string> Specifications { get; set; }
    }
}

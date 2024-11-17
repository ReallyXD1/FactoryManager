using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class WarehouseCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentCategoryId { get; set; }
        public bool IsActive { get; set; }
        public List<string> RequiredProperties { get; set; }
        public Dictionary<string, string> DefaultValues { get; set; }
        public List<string> AllowedLocations { get; set; }
        public string StorageRequirements { get; set; }
        public Dictionary<string, string> HandlingInstructions { get; set; }
        public int ItemCount { get; set; }
    }
}

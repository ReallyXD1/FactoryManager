namespace FactoryManager.Desktop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int ParentCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}

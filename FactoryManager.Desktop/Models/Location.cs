namespace FactoryManager.Desktop.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Zone { get; set; }
        public string Aisle { get; set; }
        public string Rack { get; set; }
        public string Level { get; set; }
        public string Position { get; set; }
        public double Capacity { get; set; }
        public double UsedCapacity { get; set; }
        public bool IsActive { get; set; }
    }
}

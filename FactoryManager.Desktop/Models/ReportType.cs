namespace FactoryManager.Desktop.Models
{
    public class ReportType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> AvailableFormats { get; set; }
        public bool RequiresDateRange { get; set; }
        public Dictionary<string, string> RequiredParameters { get; set; }
    }
}

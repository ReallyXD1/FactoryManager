using System;

namespace FactoryManager.Desktop.Models.Reports
{
    public class ReportDistribution
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public DateTime SentDate { get; set; }
        public string Status { get; set; }
        public string DeliveryMethod { get; set; }
        public DateTime? ReadDate { get; set; }
        public string Format { get; set; }
        public string AccessLink { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Dictionary<string, string> CustomHeaders { get; set; }
    }
}

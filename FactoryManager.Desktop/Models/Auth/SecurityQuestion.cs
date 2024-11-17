using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityQuestion
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Question { get; set; }
        public string AnswerHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public string Category { get; set; }
        public string Locale { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

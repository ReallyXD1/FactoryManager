using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLogin { get; set; }
        public List<string> Permissions { get; set; }
        public Dictionary<string, string> Preferences { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public byte[] ProfileImage { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class UserPreferences
    {
        public int UserId { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public string TimeZone { get; set; }
        public Dictionary<string, object> NotificationSettings { get; set; }
        public Dictionary<string, object> DashboardLayout { get; set; }
        public List<string> FavoriteViews { get; set; }
        public Dictionary<string, string> CustomSettings { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool AutomaticLogout { get; set; }
        public int SessionTimeout { get; set; }
    }
}

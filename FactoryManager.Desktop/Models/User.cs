using System;

namespace FactoryManager.Desktop.Models
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
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public UserSettings Settings { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }

    public class UserSettings
    {
        public string Theme { get; set; }
        public string Language { get; set; }
        public bool NotificationsEnabled { get; set; }
        public bool EmailNotificationsEnabled { get; set; }
        public string DefaultView { get; set; }
        public int ItemsPerPage { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public User User { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}

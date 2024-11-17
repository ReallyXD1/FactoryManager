namespace FactoryManager.Desktop.Models.Auth
{
    public class PasswordChange
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string SessionId { get; set; }
        public bool LogoutOtherSessions { get; set; }
        public string SecurityCode { get; set; }
    }
}

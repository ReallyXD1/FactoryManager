namespace FactoryManager.Desktop.Models.Auth
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string IpAddress { get; set; }
        public Dictionary<string, string> ClientInfo { get; set; }
    }
}

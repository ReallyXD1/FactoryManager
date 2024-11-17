namespace FactoryManager.Desktop.Models.Auth
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }
        public string DeviceId { get; set; }
        public string SessionId { get; set; }
        public Dictionary<string, string> ClientInfo { get; set; }
    }
}

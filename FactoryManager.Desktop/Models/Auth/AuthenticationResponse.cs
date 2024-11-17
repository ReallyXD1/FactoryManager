using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationResponse
    {
        public string ResponseId { get; set; }
        public string RequestId { get; set; }
        public bool IsAuthenticated { get; set; }
        public Dictionary<string, object> Claims { get; set; }
        public List<string> GrantedPermissions { get; set; }
        public string AuthMethod { get; set; }
        public DateTime Timestamp { get; set; }
        public string SessionToken { get; set; }
        public Dictionary<string, object> AdditionalData { get; set; }
        public List<string> RequiredActions { get; set; }
    }
}

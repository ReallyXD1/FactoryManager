using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class UserDevice
    {
        public string DeviceId { get; set; }
        public int UserId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceType { get; set; }
        public DateTime LastUsed { get; set; }
        public bool IsTrusted { get; set; }
        public string PushToken { get; set; }
        public Dictionary<string, string> DeviceInfo { get; set; }
        public List<string> Capabilities { get; set; }
        public string Status { get; set; }
        public DateTime RegisteredAt { get; set; }
    }
}

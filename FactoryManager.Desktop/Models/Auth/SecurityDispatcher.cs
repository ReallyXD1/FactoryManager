using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityDispatcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Handlers { get; set; }
        public Dictionary<string, object> Routes { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public TimeSpan Timeout { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public DateTime LastDispatch { get; set; }
    }
}

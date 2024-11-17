using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrentState { get; set; }
        public Dictionary<string, object> StateData { get; set; }
        public List<string> AllowedTransitions { get; set; }
        public DateTime LastTransition { get; set; }
        public string TransitionedBy { get; set; }
        public int Version { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public bool IsLocked { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBaseline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public Dictionary<string, object> Requirements { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public List<string> ApplicableSystems { get; set; }
        public bool IsMandatory { get; set; }
        public string Owner { get; set; }
        public DateTime LastReview { get; set; }
        public Dictionary<string, object> Configurations { get; set; }
    }
}

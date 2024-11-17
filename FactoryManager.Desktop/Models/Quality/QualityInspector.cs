using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Quality
{
    public class QualityInspector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Qualification { get; set; }
        public List<string> Certifications { get; set; }
        public DateTime CertificationExpiry { get; set; }
        public List<string> SpecializedAreas { get; set; }
        public int CompletedInspections { get; set; }
        public double AccuracyRate { get; set; }
        public bool IsAvailable { get; set; }
        public string CurrentAssignment { get; set; }
        public Dictionary<string, DateTime> TrainingHistory { get; set; }
    }
}

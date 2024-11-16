using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface IQualityService
    {
        Task<IEnumerable<QualityControl>> GetQualityControlsAsync(string status = null);
        Task<IEnumerable<QualityParameter>> GetQualityParametersAsync();
        Task<IEnumerable<NonConformity>> GetControlNonConformitiesAsync(int controlId);
        Task<bool> StartControlAsync(int controlId);
        Task<bool> CompleteControlAsync(int controlId);
        Task<bool> CreateNonConformityAsync(NonConformity nonConformity);
        Task<IEnumerable<QualityAlert>> GetQualityAlertsAsync();
        Task<QualityStatistics> GetQualityStatisticsAsync(DateTime startDate, DateTime endDate);
    }
}

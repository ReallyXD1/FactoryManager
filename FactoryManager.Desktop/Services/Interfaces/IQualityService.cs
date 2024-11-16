using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IQualityService
    {
        Task<IEnumerable<QualityControl>> GetQualityControlsAsync();
        Task<IEnumerable<string>> GetControlTypesAsync();
        Task<IEnumerable<string>> GetStatusesAsync();
        Task<QualityControl> CreateControlAsync(QualityControl control);
        Task StartControlAsync(int controlId);
        Task CompleteControlAsync(int controlId);
        Task<NonConformity> ReportNonConformityAsync(int controlId, NonConformity nonConformity);
        Task<QualityReport> GenerateReportAsync();
        Task<QualityStatistics> GetQualityStatisticsAsync();
    }
}

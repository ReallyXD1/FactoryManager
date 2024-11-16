using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IQualityService
    {
        Task<IEnumerable<QualityControl>> GetQualityControlsAsync();
        Task<QualityControl> GetQualityControlAsync(int controlId);
        Task<QualityControl> CreateQualityControlAsync(QualityControlCreate control);
        Task<bool> UpdateQualityControlAsync(QualityControl control);
        Task<bool> DeleteQualityControlAsync(int controlId);
        Task<QualityStatistics> GetQualityStatisticsAsync();
        Task<IEnumerable<QualityParameter>> GetQualityParametersAsync();
        Task<IEnumerable<NonConformity>> GetNonConformitiesAsync(int controlId);
        Task<NonConformity> ReportNonConformityAsync(NonConformityCreate nonConformity);
        Task<bool> ResolveNonConformityAsync(int nonConformityId, string resolution);
        Task<IEnumerable<QualityCheckList>> GetCheckListsAsync();
        Task<byte[]> GenerateQualityReportAsync(QualityReportOptions options);
        Task<IEnumerable<QualityTrend>> GetQualityTrendsAsync(QualityTrendFilter filter);
        Task<IEnumerable<QualityInspector>> GetInspectorsAsync();
    }
}

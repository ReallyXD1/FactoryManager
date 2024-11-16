using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportType>> GetReportTypesAsync();
        Task<IEnumerable<Report>> GetReportsAsync();
        Task<Report> GenerateReportAsync(int reportTypeId, DateTime startDate, DateTime endDate);
        Task ScheduleReportAsync(ReportSchedule schedule);
        Task ExportReportAsync(int reportId, string path);
        Task ShareReportAsync(int reportId, IEnumerable<string> recipients);
        Task<ReportPreview> GetReportPreviewAsync(int reportTypeId, DateTime startDate, DateTime endDate);
    }
}

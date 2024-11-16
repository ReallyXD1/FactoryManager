using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetReportsAsync();
        Task<Report> GetReportAsync(int reportId);
        Task<ReportPreview> GetReportPreviewAsync(int reportId);
        Task<Report> GenerateReportAsync(ReportGenerate options);
        Task<bool> ExportReportAsync(int reportId, string format = "PDF");
        Task<bool> ShareReportAsync(int reportId, string recipientEmail);
        Task<IEnumerable<ReportTemplate>> GetReportTemplatesAsync();
        Task<IEnumerable<ReportSchedule>> GetReportSchedulesAsync();
        Task<ReportSchedule> CreateReportScheduleAsync(ReportScheduleCreate schedule);
        Task<bool> UpdateReportScheduleAsync(ReportSchedule schedule);
        Task<bool> DeleteReportScheduleAsync(int scheduleId);
        Task<IEnumerable<ReportParameter>> GetReportParametersAsync(string reportType);
        Task<byte[]> DownloadReportAsync(int reportId);
        Task<IEnumerable<ReportFormat>> GetAvailableFormatsAsync();
        Task<Dictionary<string, object>> GetReportMetadataAsync(int reportId);
    }
}

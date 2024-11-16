using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetReportsAsync();
        Task<IEnumerable<ReportType>> GetReportTypesAsync();
        Task<Report> GenerateReportAsync(string reportType, DateTime startDate, DateTime endDate);
        Task<IEnumerable<KpiIndicator>> GetKpiIndicatorsAsync();
        Task<IEnumerable<ChartData>> GetReportChartDataAsync(int reportId);
        Task<bool> ExportReportAsync(int reportId);
        Task<bool> ShareReportAsync(int reportId);
        Task<bool> ScheduleReportAsync(ReportSchedule schedule);
    }
}

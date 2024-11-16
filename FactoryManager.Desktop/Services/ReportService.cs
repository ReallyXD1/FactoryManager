using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;

namespace FactoryManager.Desktop.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ReportService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl");
        }

        public async Task<IEnumerable<ReportType>> GetReportTypesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/reports/types");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ReportType>>();
        }

        public async Task<IEnumerable<Report>> GetReportsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/reports");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Report>>();
        }

        public async Task<Report> GenerateReportAsync(int reportTypeId, DateTime startDate, DateTime endDate)
        {
            var request = new
            {
                ReportTypeId = reportTypeId,
                StartDate = startDate,
                EndDate = endDate
            };

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/reports/generate", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Report>();
        }

        public async Task ScheduleReportAsync(ReportSchedule schedule)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/reports/schedule", schedule);
            response.EnsureSuccessStatusCode();
        }

        public async Task ExportReportAsync(int reportId, string path)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/reports/{reportId}/export");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(path, content);
        }

        public async Task ShareReportAsync(int reportId, IEnumerable<string> recipients)
        {
            var request = new { Recipients = recipients };
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/reports/{reportId}/share", request);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ReportPreview> GetReportPreviewAsync(int reportTypeId, DateTime startDate, DateTime endDate)
        {
            var request = new
            {
                ReportTypeId = reportTypeId,
                StartDate = startDate,
                EndDate = endDate
            };

            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/reports/preview", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReportPreview>();
        }
    }
}

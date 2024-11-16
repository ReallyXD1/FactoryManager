using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class ReportService : IReportService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ReportService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<Report> GenerateReportAsync(string reportType, DateTime startDate, DateTime endDate)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/reports/generate",
                    new { reportType, startDate, endDate });

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Report>();
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Generate report error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> ExportReportAsync(int reportId)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_configuration["ApiUrl"]}/reports/{reportId}/export");

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Export report error: {ex.Message}");
                return false;
            }
        }

        // Implementacja pozostałych metod interfejsu...
    }
}

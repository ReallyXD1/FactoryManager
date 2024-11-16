using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PlanningService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<PlanningTask>> GetTasksAsync(DateTime date)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"{_configuration["ApiUrl"]}/planning/tasks?date={date:yyyy-MM-dd}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<PlanningTask>>();
                }
                return new List<PlanningTask>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get tasks error: {ex.Message}");
                return new List<PlanningTask>();
            }
        }

        public async Task<bool> OptimizeScheduleAsync(DateTime date)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/planning/optimize",
                    new { date = date:yyyy - MM - dd });

            return response.IsSuccessStatusCode;
        }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Optimize schedule error: {ex.Message}");
                return false;
            }
}

        // Implementacja pozostałych metod interfejsu...
    }
}

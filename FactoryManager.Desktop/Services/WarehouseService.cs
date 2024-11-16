using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WarehouseService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<WarehouseItem>> GetWarehouseItemsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}/warehouse/items");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<WarehouseItem>>();
                }
                return new List<WarehouseItem>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get warehouse items error: {ex.Message}");
                return new List<WarehouseItem>();
            }
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_configuration["ApiUrl"]}/warehouse/locations");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<Location>>();
                }
                return new List<Location>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get locations error: {ex.Message}");
                return new List<Location>();
            }
        }

        // Implementacja pozostałych metod interfejsu...
    }
}

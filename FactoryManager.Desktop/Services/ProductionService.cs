using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IHttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ProductionService(IHttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<IEnumerable<ProductionOrder>> GetProductionOrdersAsync(string line = null, string status = null)
        {
            try
            {
                var url = $"{_configuration["ApiUrl"]}/production/orders";
                if (!string.IsNullOrEmpty(line))
                    url += $"?line={line}";
                if (!string.IsNullOrEmpty(status))
                    url += $"{(url.Contains("?") ? "&" : "?")}status={status}";

                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<ProductionOrder>>();
                }
                return new List<ProductionOrder>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Get production orders error: {ex.Message}");
                return new List<ProductionOrder>();
            }
        }

        public async Task<ProductionOrder> CreateOrderAsync(ProductionOrder order)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"{_configuration["ApiUrl"]}/production/orders",
                    order);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ProductionOrder>();
                }
                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Create order error: {ex.Message}");
                return null;
            }
        }

        // Implementacja pozostałych metod interfejsu...
    }
}

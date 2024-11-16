using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;

namespace FactoryManager.Desktop.Services
{
    public class ProductionService : IProductionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ProductionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl");
        }

        public async Task<IEnumerable<ProductionOrder>> GetProductionOrdersAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/production/orders");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ProductionOrder>>();
        }

        public async Task<IEnumerable<ProductionLine>> GetProductionLinesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/production/lines");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<ProductionLine>>();
        }

        public async Task<IEnumerable<string>> GetStatusesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/production/statuses");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<string>>();
        }

        public async Task<ProductionOrder> CreateOrderAsync(ProductionOrder order)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/production/orders", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductionOrder>();
        }

        public async Task StartProductionAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/production/orders/{orderId}/start", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task PauseProductionAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/production/orders/{orderId}/pause", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CompleteOrderAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/production/orders/{orderId}/complete", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task<ProductionStatistics> GetProductionStatisticsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/production/statistics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductionStatistics>();
        }
    }
}

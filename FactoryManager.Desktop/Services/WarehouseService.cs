using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;

namespace FactoryManager.Desktop.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public WarehouseService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiBaseUrl");
        }

        public async Task<IEnumerable<WarehouseItem>> GetWarehouseItemsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/warehouse/items");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseItem>>();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/warehouse/categories");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/warehouse/locations");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<Location>>();
        }

        public async Task<WarehouseTransaction> ReceiveItemsAsync(WarehouseTransaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/warehouse/transactions/receive", transaction);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WarehouseTransaction>();
        }

        public async Task<WarehouseTransaction> IssueItemsAsync(WarehouseTransaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/warehouse/transactions/issue", transaction);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WarehouseTransaction>();
        }

        public async Task<WarehouseTransaction> MoveItemsAsync(WarehouseTransaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/warehouse/transactions/move", transaction);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WarehouseTransaction>();
        }

        public async Task<WarehouseStatistics> GetWarehouseStatisticsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/warehouse/statistics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WarehouseStatistics>();
        }
    }
}

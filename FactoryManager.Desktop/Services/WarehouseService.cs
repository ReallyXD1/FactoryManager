using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using System.Net.Http.Json;
using System.Configuration;

namespace FactoryManager.Desktop.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificationService;

        public WarehouseService(
        HttpClient httpClient,
            IConfiguration configuration,
            INotificationService notificationService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _notificationService = notificationService;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
        }

        public async Task<IEnumerable<WarehouseItem>> GetWarehouseItemsAsync()
        {
            var response = await _httpClient.GetAsync("api/warehouse/items");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseItem>>();
            }
            return new List<WarehouseItem>();
        }

        public async Task<WarehouseItem> GetWarehouseItemAsync(int itemId)
        {
            var response = await _httpClient.GetAsync($"api/warehouse/items/{itemId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WarehouseItem>();
            }
            return null;
        }

        public async Task<bool> ReceiveItemsAsync(WarehouseTransaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync("api/warehouse/transactions/receive", transaction);
            if (response.IsSuccessStatusCode)
            {
                _notificationService.SendNotification(new Notification
                {
                    Message = $"Items received: {transaction.Quantity} {transaction.ItemName}",
                    Type = "Warehouse"
                });
                return true;
            }
            return false;
        }

        public async Task<bool> IssueItemsAsync(WarehouseTransaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync("api/warehouse/transactions/issue", transaction);
            if (response.IsSuccessStatusCode)
            {
                _notificationService.SendNotification(new Notification
                {
                    Message = $"Items issued: {transaction.Quantity} {transaction.ItemName}",
                    Type = "Warehouse"
                });
                return true;
            }
            return false;
        }

        public async Task<bool> MoveItemsAsync(WarehouseItemMove move)
        {
            var response = await _httpClient.PostAsJsonAsync("api/warehouse/transactions/move", move);
            return response.IsSuccessStatusCode;
        }

        public async Task<WarehouseStatistics> GetWarehouseStatisticsAsync()
        {
            var response = await _httpClient.GetAsync("api/warehouse/statistics");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WarehouseStatistics>();
            }
            return null;
        }

        public async Task<IEnumerable<WarehouseLocation>> GetLocationsAsync()
        {
            var response = await _httpClient.GetAsync("api/warehouse/locations");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseLocation>>();
            }
            return new List<WarehouseLocation>();
        }

        public async Task<IEnumerable<WarehouseCategory>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/warehouse/categories");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseCategory>>();
            }
            return new List<WarehouseCategory>();
        }

        public async Task<IEnumerable<WarehouseTransaction>> GetTransactionHistoryAsync(int itemId)
        {
            var response = await _httpClient.GetAsync($"api/warehouse/transactions/history/{itemId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseTransaction>>();
            }
            return new List<WarehouseTransaction>();
        }

        public async Task<IEnumerable<StockAlert>> GetStockAlertsAsync()
        {
            var response = await _httpClient.GetAsync("api/warehouse/alerts");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<StockAlert>>();
            }
            return new List<StockAlert>();
        }

        public async Task UpdateStockLevelsAsync(int itemId, int minimumLevel, int maximumLevel)
        {
            await _httpClient.PutAsJsonAsync($"api/warehouse/items/{itemId}/levels",
                new { MinimumLevel = minimumLevel, MaximumLevel = maximumLevel });
        }

        public async Task<byte[]> GenerateInventoryReportAsync(InventoryReportOptions options)
        {
            var response = await _httpClient.PostAsJsonAsync("api/warehouse/reports/inventory", options);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            return null;
        }

        public async Task<IEnumerable<WarehouseAuditLog>> GetAuditLogsAsync(WarehouseAuditFilter filter)
        {
            var response = await _httpClient.PostAsJsonAsync("api/warehouse/audit/logs", filter);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<WarehouseAuditLog>>();
            }
            return new List<WarehouseAuditLog>();
        }
    }
}

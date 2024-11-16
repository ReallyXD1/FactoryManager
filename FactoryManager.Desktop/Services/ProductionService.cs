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
    public class ProductionService : IProductionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly INotificationService _notificationService;

        public ProductionService(
        HttpClient httpClient,
            IConfiguration configuration,
            INotificationService notificationService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _notificationService = notificationService;
            _httpClient.BaseAddress = new Uri(_configuration["ApiBaseUrl"]);
        }

        public async Task<IEnumerable<ProductionOrder>> GetProductionOrdersAsync()
        {
            var response = await _httpClient.GetAsync("api/production/orders");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductionOrder>>();
            }
            return new List<ProductionOrder>();
        }

        public async Task<ProductionOrder> GetProductionOrderAsync(int orderId)
        {
            var response = await _httpClient.GetAsync($"api/production/orders/{orderId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductionOrder>();
            }
            return null;
        }

        public async Task<ProductionOrder> CreateProductionOrderAsync(ProductionOrderCreate order)
        {
            var response = await _httpClient.PostAsJsonAsync("api/production/orders", order);
            if (response.IsSuccessStatusCode)
            {
                var createdOrder = await response.Content.ReadFromJsonAsync<ProductionOrder>();
                _notificationService.SendNotification(new Notification
                {
                    Message = $"New production order created: {createdOrder.Id}",
                    Type = "Production"
                });
                return createdOrder;
            }
            throw new Exception("Failed to create production order");
        }

        public async Task<bool> StartProductionAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"api/production/orders/{orderId}/start", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PauseProductionAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"api/production/orders/{orderId}/pause", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CompleteOrderAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"api/production/orders/{orderId}/complete", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CancelOrderAsync(int orderId)
        {
            var response = await _httpClient.PostAsync($"api/production/orders/{orderId}/cancel", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<ProductionStatistics> GetProductionStatisticsAsync()
        {
            var response = await _httpClient.GetAsync("api/production/statistics");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ProductionStatistics>();
            }
            return null;
        }

        public async Task<IEnumerable<ProductionLine>> GetProductionLinesAsync()
        {
            var response = await _httpClient.GetAsync("api/production/lines");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductionLine>>();
            }
            return new List<ProductionLine>();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("api/production/products");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            }
            return new List<Product>();
        }

        public async Task<IEnumerable<ProductionShift>> GetShiftsAsync()
        {
            var response = await _httpClient.GetAsync("api/production/shifts");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductionShift>>();
            }
            return new List<ProductionShift>();
        }

        public async Task UpdateOrderProgressAsync(int orderId, double progress)
        {
            await _httpClient.PutAsJsonAsync($"api/production/orders/{orderId}/progress", new { Progress = progress });
        }

        public async Task<IEnumerable<ProductionEvent>> GetProductionEventsAsync(int orderId)
        {
            var response = await _httpClient.GetAsync($"api/production/orders/{orderId}/events");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProductionEvent>>();
            }
            return new List<ProductionEvent>();
        }

        public async Task LogProductionEventAsync(ProductionEvent productionEvent)
        {
            await _httpClient.PostAsJsonAsync("api/production/events", productionEvent);
        }
    }
}

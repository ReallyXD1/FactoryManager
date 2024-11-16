using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Infrastructure
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _client;

        public HttpClientWrapper(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T content)
        {
            return await _client.PostAsJsonAsync(url, content);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string url, T content)
        {
            return await _client.PutAsJsonAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await _client.DeleteAsync(url);
        }
    }
}

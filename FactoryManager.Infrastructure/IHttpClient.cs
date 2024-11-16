using System.Net.Http;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Infrastructure
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync<T>(string url, T content);
        Task<HttpResponseMessage> PutAsync<T>(string url, T content);
        Task<HttpResponseMessage> DeleteAsync(string url);
    }
}

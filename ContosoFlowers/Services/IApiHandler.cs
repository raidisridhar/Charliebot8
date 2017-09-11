using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoFlowers.Services
{
    public interface IApiHandler
    {
        string GetJsonAsync<T>(string url, IDictionary<string, string> requestParameters = null, IDictionary<string, string> headers = null) where T : class;

        string GetStringAsync(string url, IDictionary<string, string> requestParameters = null, IDictionary<string, string> headers = null);
    }
}

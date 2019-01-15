using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Playground.MiscUtilities
{
    public class RestService
    {
        private HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<T> GetRequest<T>(string url)
        {
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                bool isParsingSuccessful = JsonHelper.TryParse(content, out T desiredObject);

                return desiredObject;
            }

            // If something bad happens.
            System.Diagnostics.Debug.WriteLine(response);


            return default(T);
        }
    }
}

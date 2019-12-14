using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpRequestDotNet.Services
{
    public class HttpService
    {
        private const string _servicePath = "PortfolioManager/UniversalService";
        private const int _httpClientTimeoutExtendedTime = 5000;
        private const int _integrationModuleTimeout = 5000;

        public async Task<string> SendAsync(string url, string request){

            var content = new FormUrlEncodedContent(PrepareContent(request, _integrationModuleTimeout));
            var tokenSource = new CancellationTokenSource();

            using(HttpClient client = new HttpClient()){
                HttpResponseMessage response = await client.PostAsync("", content, tokenSource.Token).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return result;
            }
        }

        private IEnumerable<KeyValuePair<string, string>> PrepareContent(string request, int integrationModuleTimeout)
        {
            yield return new KeyValuePair<string, string>("body", request);

            if (integrationModuleTimeout > 0)
            {
                yield return new KeyValuePair<string, string>("timeoutMs", integrationModuleTimeout.ToString());
            }
        }
    }
}
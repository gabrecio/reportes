using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ERP.Reports.Api.Services.OAuths
{
    public class OauthServerApiClientBase
    {
        public async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(CancellationToken cancellationToken) => await Task.FromResult(new HttpRequestMessage());

        public async Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, StringBuilder urlBuilder, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task PrepareRequestAsync(HttpClient client, HttpRequestMessage request, string url, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public async Task ProcessResponseAsync(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
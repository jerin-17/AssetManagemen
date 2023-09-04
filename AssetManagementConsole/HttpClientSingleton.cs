using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Net.Http;
namespace AssetManagementConsole
{
    

    public sealed class HttpClientSingleton
    {
        private static readonly Lazy<HttpClient> lazyClient = new Lazy<HttpClient>(() =>
        {
            var httpClient = new HttpClient();
            return httpClient;
        });

        public static HttpClient Instance => lazyClient.Value;

        private HttpClientSingleton()
        {
        }
    }

}
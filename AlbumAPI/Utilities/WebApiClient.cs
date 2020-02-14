using AlbumAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlbumAPI.Utilities
{
    public class WebApiClient : IWebApiClient
    {
        private System.Net.Http.HttpClient _client;
        public WebApiClient()
        {
            if (_client == null)
            {
                _client = new System.Net.Http.HttpClient();
            }
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            return _client.GetAsync(url);
        }
    }
}

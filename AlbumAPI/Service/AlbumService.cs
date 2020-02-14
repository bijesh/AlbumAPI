using AlbumAPI.Contract;
using AlbumAPI.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IWebApiClient _webApiClient;
        private readonly IConfiguration _configuration;
        public AlbumService(IWebApiClient webApiClient, IConfiguration configuration)
        {
            _webApiClient = webApiClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albumUrl = _configuration.GetSection("AlbumApi");
            var httpEndpoint = albumUrl["http"];
            var response = await _webApiClient.GetAsync(httpEndpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var albumList = JsonConvert.DeserializeObject<List<Album>>(apiResponse);
            return albumList;
        }

    }
}

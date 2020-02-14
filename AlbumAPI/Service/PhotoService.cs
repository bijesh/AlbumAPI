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
    public class PhotoService : IPhotoService
    {
        private readonly IWebApiClient _webApiClient;
        private readonly IConfiguration _configuration;
        public PhotoService(IWebApiClient webApiClient, IConfiguration configuration)
        {
            _webApiClient = webApiClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Photo>> GetPhotos()
        {
            var photoUrl = _configuration.GetSection("PhotoApi");
            var httpEndpoint = photoUrl["http"];
            var response = await _webApiClient.GetAsync(httpEndpoint);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var photoList = JsonConvert.DeserializeObject<List<Photo>>(apiResponse);
            return photoList;
        }
    }
}

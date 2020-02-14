using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlbumAPI.Interface
{
    public interface IWebApiClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}

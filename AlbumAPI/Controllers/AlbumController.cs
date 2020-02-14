using System;
using System.Threading.Tasks;
using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AlbumAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AlbumController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public AlbumController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("/album/user/{id}")]
         public async Task<UserAlbumViewModel> Get(int id)
        {
            UserAlbumViewModel userAlbums= new UserAlbumViewModel();
            userAlbums = await _searchService.GetUserAlbums(id);
            
            return userAlbums;
        }
    }
}
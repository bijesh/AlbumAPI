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

        [ActionName("user")]
        [HttpGet]
        public async Task<UserAlbumViewModel> Get(int userId)
        {
            UserAlbumViewModel userAlbums= new UserAlbumViewModel();
            userAlbums = await _searchService.GetUserAlbums(userId);
            
            return userAlbums;
        }
    }
}
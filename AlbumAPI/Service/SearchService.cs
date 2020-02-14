using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Service
{
    public class SearchService : ISearchService
    {
        private readonly IPhotoService _photoService;
        private readonly IAlbumService _albumService;
        private readonly IUserAlbumViewModelBuilder _userAlbumViewModelBuilder;
        private readonly IAlbumViewModelBuilder _albumViewModelBuilder;

        public SearchService(IPhotoService photoService, IAlbumService albumService, IUserAlbumViewModelBuilder userAlbumViewModelBuilder, IAlbumViewModelBuilder albumViewModelBuilder)
        {
            _photoService = photoService;
            _albumService = albumService;
            _userAlbumViewModelBuilder = userAlbumViewModelBuilder;
            _albumViewModelBuilder = albumViewModelBuilder;
        }

        public async Task<UserAlbumViewModel> GetUserAlbums(int userId)
        {
           var allAlbums = await _albumService.GetAlbums();
           var userAlbums = allAlbums.Where(album => album.userId == userId).ToList();
           var allPhotos = await _photoService.GetPhotos();
           
            List<AlbumViewModel> albumViewModelList = new List<AlbumViewModel>();
            foreach(var album in userAlbums)
            {
                var photosFromAlbum = allPhotos.Where(photo => photo.albumId == album.id);
                albumViewModelList.Add(_albumViewModelBuilder.Build(album, photosFromAlbum));
            }

           return  _userAlbumViewModelBuilder.Build(userId, albumViewModelList);
        }

         
    }
}

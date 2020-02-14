using AlbumAPI.Contract;
using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.ViewModelBuilder
{
    public class AlbumViewModelBuilder : IAlbumViewModelBuilder
    {
        private readonly IPhotoViewModelBuilder _photoViewModelBuilder;
        public AlbumViewModelBuilder(IPhotoViewModelBuilder photoViewModelBuilder)
        {
            _photoViewModelBuilder = photoViewModelBuilder;
        }
        public AlbumViewModel Build(Album album, IEnumerable<Photo> photos)
        {
            return new AlbumViewModel
            {
                id= album.id,
                title = album.title,
                Photos= photos.Select(photo => _photoViewModelBuilder.Build(photo))
            };
        }
       
    }
}

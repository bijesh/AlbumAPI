using AlbumAPI.Contract;
using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.ViewModelBuilder
{
    public class PhotoViewModelBuilder : IPhotoViewModelBuilder
    {
        public PhotoViewModel Build(Photo photo)
        {
            return new PhotoViewModel
            {
                id = photo.id,
                title = photo.title,
                thumbnailUrl = photo.thumbnailUrl,
                url = photo.url
            };
        }
    }
}

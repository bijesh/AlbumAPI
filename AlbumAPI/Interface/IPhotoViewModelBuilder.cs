using AlbumAPI.Contract;
using AlbumAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Interface
{
    public interface IPhotoViewModelBuilder
    {
        public PhotoViewModel Build(Photo photo);
    }
}

using AlbumAPI.Contract;
using AlbumAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Interface
{
    public interface IAlbumViewModelBuilder
    {
        public AlbumViewModel Build(Album album,IEnumerable<Photo> photos);
    }
}

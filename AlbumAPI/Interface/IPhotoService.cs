using AlbumAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Interface
{
    public interface IPhotoService
    {
        Task<IEnumerable<Photo>> GetPhotos();
    }
}

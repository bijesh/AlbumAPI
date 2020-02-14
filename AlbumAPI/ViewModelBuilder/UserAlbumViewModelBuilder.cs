using AlbumAPI.Contract;
using AlbumAPI.Interface;
using AlbumAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.ViewModelBuilder
{
    public class UserAlbumViewModelBuilder : IUserAlbumViewModelBuilder
    {
        public UserAlbumViewModel Build(int userId, IEnumerable<AlbumViewModel> albumViewModelList)
        {
            return new UserAlbumViewModel
            {
                userId = userId,
                Albums = albumViewModelList
            };
        }
    }
}

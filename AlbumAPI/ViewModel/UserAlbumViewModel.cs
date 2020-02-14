using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.ViewModel
{
    public class UserAlbumViewModel
    {
        public int userId { get; set; }
        public IEnumerable<AlbumViewModel> Albums { get; set; }
    }
}

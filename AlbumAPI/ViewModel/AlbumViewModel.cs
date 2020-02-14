using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.ViewModel
{
    public class AlbumViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public IEnumerable<PhotoViewModel> Photos { get; set; }
    }
}

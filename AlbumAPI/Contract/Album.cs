using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumAPI.Contract
{
    public class Album
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
    }
}

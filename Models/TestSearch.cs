using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BaiThucHanh1402.Models
{
    public class TestSearch
    {
        public List<Student> Students { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}
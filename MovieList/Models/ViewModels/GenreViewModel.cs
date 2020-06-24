using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models.ViewModels
{
    public class GenreViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Movie> Genres { get; set; }
        public string CurrentGenre { get; set; }
    }
}

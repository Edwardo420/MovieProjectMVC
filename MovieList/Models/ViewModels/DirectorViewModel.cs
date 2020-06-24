using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models.ViewModels
{
    public class DirectorViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Movie> Directors { get; set; }
        public string CurrentDirector { get; set; }
    }
}

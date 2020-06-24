using Microsoft.AspNetCore.Mvc;
using MovieAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Component
{
    public class GenreMenu : ViewComponent
    {
        private readonly IGenreRepository _genreRepository;
        public GenreMenu(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _genreRepository.Genres.OrderBy(s => s.Name);
            return View(genres);
        }
    }
}


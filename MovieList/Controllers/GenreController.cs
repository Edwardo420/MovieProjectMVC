using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieAccess.Interfaces;
using MovieList.Models.ViewModels;
using MovieStructure.Models;

namespace MovieList.Controllers
{
    public class GenreController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public GenreController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public ViewResult ListGenre(string genre)
        {
            string _genre = genre;
            IEnumerable<Movie> movies;
            string currentGenre = string.Empty;

            if (string.IsNullOrEmpty(genre))
            {
                movies = _movieRepository.Movies;
                currentGenre = "All Movies";
            }
            else
            {
                if (string.Equals("Action", _genre, StringComparison.OrdinalIgnoreCase))
                    movies = _movieRepository.Movies.Where(s => s.Genre.Name.Equals("Action"));
                else if (string.Equals("Drama", _genre, StringComparison.OrdinalIgnoreCase))
                    movies = _movieRepository.Movies.Where(s => s.Genre.Name.Equals("Drama"));
                else {/*if (string.Equals("Comedy", _genre, StringComparison.OrdinalIgnoreCase))*/
                    movies = _movieRepository.Movies.Where(s => s.Genre.Name.Equals("Comedy"));
                        }


                currentGenre = _genre;
            }

            return View("~/Views/Movie/ListGenre.cshtml", new GenreViewModel
            {
                Genres = movies,
                CurrentGenre = currentGenre
            });
        }
    }
}
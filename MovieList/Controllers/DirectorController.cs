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
    public class DirectorController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        public DirectorController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public ViewResult ListDirector(string director)
        {
            string _director = director;
            IEnumerable<Movie> movies;
            string currentDirector = string.Empty;

            if (string.IsNullOrEmpty(director))
            {
                movies = _movieRepository.Movies;
                currentDirector = "All Movies";
            }
            else
            {
                if (string.Equals("Fleischer", _director, StringComparison.OrdinalIgnoreCase))
                    movies = _movieRepository.Movies.Where(s => s.Director.LastName.Equals("Fleischer"));
                else if (string.Equals("Nolan", _director, StringComparison.OrdinalIgnoreCase))
                    movies = _movieRepository.Movies.Where(s => s.Director.LastName.Equals("Nolan"));
                else if (string.Equals("Fowler", _director, StringComparison.OrdinalIgnoreCase))
                    movies = _movieRepository.Movies.Where(s => s.Director.LastName.Equals("Fowler"));
                else{ /*if (string.Equals("Stahelski", _director, StringComparison.OrdinalIgnoreCase))*/
                    movies = _movieRepository.Movies.Where(s => s.Director.LastName.Equals("Stahelski"));

            };

                currentDirector = _director;
            }

            return View("~/Views/Movie/ListDirector.cshtml", new DirectorViewModel
            {
                Directors = movies,
                CurrentDirector = currentDirector
            });
        }
    }
}
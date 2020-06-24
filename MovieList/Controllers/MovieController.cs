using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieAccess.Interfaces;
using MovieList.Models.ViewModels;
using MovieStructure.Models;

namespace MovieList.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

        }


        //[Authorize(Roles = "Administrator")]
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Movie> movies;
            string currentMovie = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                movies = _movieRepository.Movies.OrderBy(p => p.MovieID);
            }
            else
            {
                movies = _movieRepository.Movies.Where(p => p.Title.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Movie/List.cshtml", new MovieListViewModel { Movies = movies, CurrentMovie = "All movies" });
        }

        public ViewResult Details(int movieId)
        {
            var movie = _movieRepository.Movies.FirstOrDefault(d => d.MovieID == movieId);
            if (movie == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(movie);
        }
    }
}
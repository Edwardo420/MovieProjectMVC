
using MovieAccess.Interfaces;
using MovieAccess.Repositories;
using MovieStructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieList.Models.ViewModels;
using System.Linq;
using MovieAccess.Services;

namespace MovieList.Controllers
{
    public class FavoriteListController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly FavoriteService _favoriteService;

        public FavoriteListController(IMovieRepository movieRepository, FavoriteService favoriteService)
        {
            _movieRepository = movieRepository;
            _favoriteService = favoriteService;
        }

        [Authorize]
        public ViewResult Index()
        {
            var items = _favoriteService.GetFavoriteListItems();
            _favoriteService.FavoriteListItems = items;

            var favoriteListViewModel = new FavoriteListViewModel
            {
                FavoriteService = _favoriteService,
            };
            return View(favoriteListViewModel);
        }

        [Authorize]
        public RedirectToActionResult AddToFavoriteList(int movieId)
        {
            var selectedMovie = _movieRepository.Movies.FirstOrDefault(p => p.MovieID == movieId);
            if (selectedMovie != null)
            {
                _favoriteService.AddToList(selectedMovie, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromFavoriteList(int movieId)
        {
            var selectedMovie = _movieRepository.Movies.FirstOrDefault(p => p.MovieID == movieId);
            if (selectedMovie != null)
            {
                _favoriteService.RemoveFromList(selectedMovie);
            }
            return RedirectToAction("Index");
        }
    }
}

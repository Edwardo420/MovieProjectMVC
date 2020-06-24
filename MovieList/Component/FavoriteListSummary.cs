using Microsoft.AspNetCore.Mvc;
using MovieAccess.Services;
using MovieList.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Component
{
    public class FavoriteListSummary : ViewComponent
    {
        private readonly FavoriteService _favoriteList;
        public FavoriteListSummary(FavoriteService favoriteRepository)
        {
            _favoriteList = favoriteRepository;
        }

        public IViewComponentResult Invoke()
        {
            var items = _favoriteList.GetFavoriteListItems();
            _favoriteList.FavoriteListItems = items;

            var favoriteListViewModel = new FavoriteListViewModel
            {
                FavoriteService = _favoriteList,
            };
            return View(favoriteListViewModel);
        }


    }
}

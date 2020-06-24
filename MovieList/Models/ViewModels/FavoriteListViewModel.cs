using MovieAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Models.ViewModels
{
    public class FavoriteListViewModel
    {
        public FavoriteService FavoriteService { get; set; }
    }
}

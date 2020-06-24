using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MovieAccess.Services
{
    public class FavoriteService
    {

        private readonly ApplicationDbContext _appDbContext;
        private FavoriteService(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [Key]
        public string FavoriteListId { get; set; }

        public List<FavoriteListItem> FavoriteListItems { get; set; }

        public static FavoriteService GetList(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new FavoriteService(context) { FavoriteListId = cartId };
        }

        public void AddToList(Movie movie, int amount)
        {
            amount = 0;
            var favoriteListItem =
                    _appDbContext.FavoriteListItems.SingleOrDefault(
                        s => s.Movie.MovieID == movie.MovieID && s.FavoriteListId == FavoriteListId);

            if (favoriteListItem == null)
            {
                favoriteListItem = new FavoriteListItem
                {
                    FavoriteListId = FavoriteListId,
                    Movie = movie,
                    Amount = 1
                };

                _appDbContext.FavoriteListItems.Add(favoriteListItem);
            }
            else
            {
                //favoriteMovieItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromList(Movie movie)
        {
            var favoriteListItem =
                    _appDbContext.FavoriteListItems.SingleOrDefault(
                        s => s.Movie.MovieID == movie.MovieID && s.FavoriteListId == FavoriteListId);

            var localAmount = 0;

            if (favoriteListItem != null)
            {
                if (favoriteListItem.Amount > 1)
                {
                    favoriteListItem.Amount--;
                    localAmount = favoriteListItem.Amount;
                }
                else
                {
                    _appDbContext.FavoriteListItems.Remove(favoriteListItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<FavoriteListItem> GetFavoriteListItems()
        {
            return FavoriteListItems ??
                   (FavoriteListItems =
                       _appDbContext.FavoriteListItems.Where(c => c.FavoriteListId == FavoriteListId)
                           .Include(s => s.Movie)
                           .ToList());
        }

        public void ClearList()
        {
            var cartItems = _appDbContext
                .FavoriteListItems
                .Where(cart => cart.FavoriteListId == FavoriteListId);

            _appDbContext.FavoriteListItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }
    }
}
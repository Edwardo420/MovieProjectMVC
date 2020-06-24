using Microsoft.EntityFrameworkCore;
using MovieAccess.Interfaces;
using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public MovieRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Movie> Movies => _appDbContext.Movies.Include(c => c.Director).Include(c => c.Genre);

        public Movie GetMovieById(int movieID) => _appDbContext.Movies.FirstOrDefault(p => p.MovieID == movieID);
    }
}
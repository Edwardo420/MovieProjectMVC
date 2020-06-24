using MovieAccess.Interfaces;
using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public GenreRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Genre> Genres => _appDbContext.Genres;
    }
}
using MovieAccess.Interfaces;
using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAccess.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        public DirectorRepository(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Director> Directors => _appDbContext.Directors;
    }
}
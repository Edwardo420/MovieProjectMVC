using Microsoft.AspNetCore.Mvc;
using MovieAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieList.Component
{
    public class DirectorMenu : ViewComponent
    {
        private readonly IDirectorRepository _directorRepository;
        public DirectorMenu(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public IViewComponentResult Invoke()
        {
            var directors = _directorRepository.Directors.OrderBy(s => s.LastName);
            return View(directors);
        }
    }
}

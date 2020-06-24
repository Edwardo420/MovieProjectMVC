using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAccess.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Genres { get; }
    }
}
﻿using MovieStructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieAccess.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
    }
}
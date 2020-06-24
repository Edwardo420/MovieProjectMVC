using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStructure.Models
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        public List<Movie> Movies { get; set; }
    }
}

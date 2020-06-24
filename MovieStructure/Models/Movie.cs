using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStructure.Models
{
    public class Movie
    {
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required] 
        public string Image { get; set; }
        public int DirectorID { get; set; }
        public virtual Director Director { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}

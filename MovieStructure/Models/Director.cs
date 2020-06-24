using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStructure.Models
{
    public class Director 
    {
        [Required]
        public int DirectorID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public List<Movie> Movies { get; set; }
    }
}

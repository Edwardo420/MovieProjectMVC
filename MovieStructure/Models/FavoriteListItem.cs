using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStructure.Models
{
    public class FavoriteListItem
    {
        public int FavoriteListItemId { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string FavoriteListId { get; set; }
    }
}
using System;

namespace MoviesTestAPI.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovies.Models
{
    public class Movies
    {
        [Key]
        public string movies { get; set; }
        public string year { get; set; }
        public string genre { get; set; }
        public string rating { get; set; }
        public string one_line { get; set; }
        public string stars { get; set; }
        public string votes { get; set; }
        public string runtime { get; set; }
        public string gross { get; set; }
    }

    public class MoviesUpdate
    {
        public string year { get; set; }
        public string genre { get; set; }
        public string rating { get; set; }
        public string one_line { get; set; }
        public string stars { get; set; }
        public string votes { get; set; }
        public string runtime { get; set; }
        public string gross { get; set; }
    }
}

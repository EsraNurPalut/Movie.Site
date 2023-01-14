using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Site.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [StringLength(30)]
        public string MovieName { get; set; }

        public string MovieDescription { get; set; }

        public string MovieType { get; set; }
    }
}

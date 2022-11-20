using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Global_Cinema.Models
{
    [Table("movieTable")]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public Nullable<int> Year { get; set; }
        public string Types { get; set; }
        public string imageUrl { get; set; }
    }
}
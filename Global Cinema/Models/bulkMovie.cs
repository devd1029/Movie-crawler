using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Global_Cinema.Models
{   
    [Table("tableBulkMovies")]
    public class bulkMovie
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int duration { get; set; }
        public string genre { get; set; }
        public string uri { get; set; }
        public string imageUrl { get; set; }
        public List<string> ImageSlides { get; set; }
    }
}
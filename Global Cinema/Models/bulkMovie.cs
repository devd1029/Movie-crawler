using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string responseString;
        private JToken result;
        private List<JToken> x1;

        public List<bulkMovie> bulkMovies { get; set; }
        public bulkMovie(string responseString)
        {
            this.responseString = responseString;
        
        }

        public bulkMovie(JToken result)
        {
            this.result = result;
            foreach(var item in result)
            {
                Title = item.Children()["title"].ToString();
                Description = item.Children()["description"].ToString();
                genre = item.Children()["genre"][0].ToString();
                uri = item.Children()["uri"].ToString();
                imageUrl = item.Children()["images"][0].ToString();
                ImageSlides = item.Children()["images"].ToList();
            }
           
        }

        public bulkMovie(List<JToken> x1)
        {
            this.x1 = x1;

        }

        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int duration { get; set; }
        public string genre { get; set; }
        public string uri { get; set; }
        public string imageUrl { get; set; }
        public List<JToken> ImageSlides { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Global_Cinema.Models
{
    [Table("movieTable")]
    public class Movie
    {
        private JToken result;
        public Movie()
        {

        }

        public Movie(JToken result)
        {
            this.result = result;
            string baseurl = "https://img1.hotstarext.com/image/upload/f_auto,t_web_vl_1_5x/";
            foreach (var item in result)
            {
                Name = item.Value<string>("title");
                Language = item.Value<JArray>("lang").ToObject<List<string>>().FirstOrDefault();
                Year = item.Value<int>("year");
                Types = item.Value<JArray>("genre").ToObject<List<string>>().FirstOrDefault();
                imageUrl = baseurl+item["images"].Values().ToList().FirstOrDefault();
            }
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public Nullable<int> Year { get; set; }
        public string Types { get; set; }
        public string imageUrl { get; set; }
    }
}
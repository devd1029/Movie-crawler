namespace Global_Cinema.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("movieTable")]
    public partial class movieTable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Language { get; set; }

        public int? Year { get; set; }

        public string Types { get; set; }

        public string imageUrl { get; set; }
    }
}

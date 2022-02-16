using System.ComponentModel.DataAnnotations;

namespace gregslistSql.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string imgUrl { get; set; }


        [Range(1904, 2023)]
        public int YearMade { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

    }
}


using System.ComponentModel.DataAnnotations;

namespace gregslistSql.Models
{
    public class House
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Range(0, 100)]
        public int Beds { get; set; }

        [Range(0, int.MaxValue)]
        public int Sqft { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }

    }
}
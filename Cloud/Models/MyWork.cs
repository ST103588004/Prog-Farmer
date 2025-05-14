using System.ComponentModel.DataAnnotations;

namespace Cloud.Models
{
    public class MyWork
    {
        [Key]
        public int productID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public string Category { get; set; }

        public string Availablility { get; set; }

        public string ImageUrl { get; set; }
    }
}

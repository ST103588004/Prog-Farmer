using System;
using System.ComponentModel.DataAnnotations;

namespace Cloud.Models
{
    public class History
    {
        [Key]
        public int HistoryID { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public int productID { get; set; }

        [Required]
        public string ProductName { get; set; } // New Property for Product Name

        [Required]
        public string ShippingAddress { get; set; }

        [Required]
        public string ShippingStatus { get; set; }

        [Required]
        public DateTime HistoryDate { get; set; }
    }
}

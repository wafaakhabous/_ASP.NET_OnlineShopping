using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http; // Add this namespace for IFormFile

namespace ModelAsp1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Display(Name = "Date")]

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Category")]
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public string imageUrl { get; set; }
    }
}

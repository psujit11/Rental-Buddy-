using System.ComponentModel.DataAnnotations;

namespace Rental.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }


        [Required,
        MaxLength(13)]
        public string Skuid { get; set; }

        [Required,
        DataType(DataType.Date),
        Display(Name = "Manufactured Date")]
        public DateTime ManufactureDate { get; set; }

        [Required,
        DataType(DataType.Currency)]
        public int Price { get; set; }

        [Required]
        public string Owner { get; set; }

        [Display(Name = "Image ")]
        public string ImageUrl { get; set; }
    }
}

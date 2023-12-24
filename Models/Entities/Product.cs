using System.ComponentModel.DataAnnotations;
using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan")]
        public string? FilePath { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Text { get; set; }
    }
}

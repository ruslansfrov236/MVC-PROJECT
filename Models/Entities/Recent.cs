using Task_15.Models.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task_15.Models.Entities
{
    public class Recent:BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "zorunlu alan")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}

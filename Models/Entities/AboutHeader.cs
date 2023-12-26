using System.ComponentModel.DataAnnotations;
using Task_15.Models.Customers;
using System.ComponentModel.DataAnnotations.Schema;
namespace Task_15.Models.Entities
{
    public class AboutHeader : BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Text { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? UrlText { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Url { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Description { get; set; }
    }
}

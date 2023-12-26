using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_15.Models.Dto.ContactHeader_Dto
{
    public class CreateContactHeader_Dto
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Link { get; set; }

        public string? FilePath { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}

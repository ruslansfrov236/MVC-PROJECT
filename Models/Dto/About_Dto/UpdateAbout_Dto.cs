using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_15.Models.Dto.About_Dto
{
    public class UpdateAbout_Dto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Description { get; set; }

        public string FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
    }
}

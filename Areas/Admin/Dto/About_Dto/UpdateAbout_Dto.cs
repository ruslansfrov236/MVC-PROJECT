using System.ComponentModel.DataAnnotations;

namespace Task_15.Areas.Admin.Dto.About_Dto
{
    public class UpdateAbout_Dto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string FilePath { get; set; }
    }
}

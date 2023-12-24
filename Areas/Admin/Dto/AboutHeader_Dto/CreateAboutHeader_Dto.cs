using System.ComponentModel.DataAnnotations;

namespace Task_15.Areas.Admin.Dto.AboutHeader_Dto
{
    public class CreateAboutHeader_Dto
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? FilePath { get; set; }
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

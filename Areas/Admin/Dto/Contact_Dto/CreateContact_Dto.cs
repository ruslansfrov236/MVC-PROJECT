using System.ComponentModel.DataAnnotations;

namespace Task_15.Areas.Admin.Dto.Contact_Dto
{
    public class CreateContact_Dto
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TitleWork { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Telephone { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Task_15.Areas.Admin.Dto.ContactInfo_Dto
{
    public class CreateContactInfo_Dto
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TitleText { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Description { get; set; }
    }
}

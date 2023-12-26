using System.ComponentModel.DataAnnotations;

namespace Task_15.Models.Dto.ContactInfo_Dto
{
    public class UpdateContactInfo_Dto
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TitleText { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Description { get; set; }
    }
}

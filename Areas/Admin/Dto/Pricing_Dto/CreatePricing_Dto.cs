using System.ComponentModel.DataAnnotations;

namespace Task_15.Areas.Admin.Dto.Work_Dto
{
    public class CreatePricing_Dto
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? PricingUser { get; set; }
        public string? PricngName { get; set; }

        [Required(ErrorMessage = "zorunlu alan ")]
        public string? PriceCategory { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TotalMemory { get; set; }
    }
}

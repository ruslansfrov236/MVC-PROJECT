using System.ComponentModel.DataAnnotations;

namespace Task_15.Models.Dto.Pricing_Dto
{
    public class UpdatePricing_Dto
    {
        public string Id { get; set; }
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

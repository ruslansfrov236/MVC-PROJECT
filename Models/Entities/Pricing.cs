using System.ComponentModel.DataAnnotations;
using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class Pricing:BaseEntity
    {
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? PricingUser { get; set; }
      
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? PriceCategory { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public  decimal Price { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? TotalMemory { get; set; }

        public string? PricngName { get; set; }
    }
}

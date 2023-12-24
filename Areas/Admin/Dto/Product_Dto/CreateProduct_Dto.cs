using System.ComponentModel.DataAnnotations;

namespace Task_15.Areas.Admin.Data.Product_Dto
{
    public class CreateProduct_Dto
    {
        public string? FilePath { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Text { get; set; }
        public string? PricngName { get; set; }

    }
}

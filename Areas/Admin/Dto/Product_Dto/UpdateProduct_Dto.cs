

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_15.Areas.Admin.Data.Product_Dto
{
    public class UpdateProduct_Dto
    {

        public string? Id { get; set; }
        [Required(ErrorMessage ="zorunlu alan")]
        public string? FilePath { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan")]
        public string? Text { get; set; }
        

    }
}

using System.ComponentModel.DataAnnotations;
using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class Contact:BaseEntity
    {
        [Required(ErrorMessage ="zorunlu alan ")]
        public string? TitleWork { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public  string?  Telephone { get; set; }  
    }
}

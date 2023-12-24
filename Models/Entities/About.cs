
using System.ComponentModel.DataAnnotations;
using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class About:BaseEntity
    {

        [Required(ErrorMessage="zorunlu alan ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string Description { get; set; }
        [Required(ErrorMessage = "zorunlu alan ")]
        public string FilePath { get; set; }
    }
}

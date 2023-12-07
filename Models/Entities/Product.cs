using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class Product:BaseEntity
    {
        public string FilePath { get; set; } 
        public string Title { get; set; } 
        public string Text { get; set; }
    }
}

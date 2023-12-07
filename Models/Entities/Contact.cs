using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class Contact:BaseEntity
    {
        public string TitleWork { get; set; }   
        public string FullName { get; set; }

        public  string Telephone { get; set; }  
    }
}

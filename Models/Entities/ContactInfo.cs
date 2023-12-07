using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class ContactInfo:BaseEntity
    {

        public  string  Title { get; set; } 

        public string TitleText { get; set; } 
        public  string  Description { get; set; }

    }
}

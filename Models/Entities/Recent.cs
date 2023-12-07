using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class Recent:BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string FilePath { get; set; }
    }
}

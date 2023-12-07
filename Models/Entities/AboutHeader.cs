using Task_15.Models.Customers;

namespace Task_15.Models.Entities
{
    public class AboutHeader : BaseEntity
    {
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string UrlText { get; set; } 
        public string Url { get; set; }
        public string Description { get; set; }
    }
}

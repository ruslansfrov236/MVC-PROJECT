
using C=Task_15.Models.Entities;
namespace Task_15.ViewsModels.Contact
{
    public class ContactIndexViewModels
    {
        public List<C::Contact> Contacts = new List<C::Contact>();

        public C::ContactInfo ContactInfo;

    }
}

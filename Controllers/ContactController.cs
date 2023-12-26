using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Context;
using Task_15.ViewsModels.Contact;

namespace Task_15.Controllers
{
    public class ContactController : Controller
    {

        readonly private Task_15DbContext _task_15DbContext;

        public ContactController(Task_15DbContext task_15DbContext)
        {
            _task_15DbContext = task_15DbContext;
        }
        public async Task<IActionResult> Index()
        {
            var contacts = await _task_15DbContext.Contacts.ToListAsync();
            var contactInfo = await _task_15DbContext.ContactsInfo.FirstOrDefaultAsync();
            var contactHeader= await _task_15DbContext.ContactHeader.FirstOrDefaultAsync();
            ContactIndexViewModels models = new ContactIndexViewModels()
            {
                Contacts= contacts,
                ContactInfo=contactInfo,
                ContactHeader=contactHeader
            };

            return View(models);
        }
    }
}

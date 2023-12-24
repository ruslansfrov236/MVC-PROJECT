using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Areas.Admin.Dto.Contact_Dto;
using Task_15.Areas.Admin.Dto.ContactInfo_Dto;
using Task_15.Models.Context;
using Task_15.Models.Entities;

namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactInfoController : Controller
    {

        readonly private Task_15DbContext _context;

        public ContactInfoController(Task_15DbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
        {

            var contacts = await _context.ContactsInfo
                                      .Select(pr => new ContactInfo()
                                      {
                                          Id = pr.Id,
                                         Title = pr.Title,
                                         TitleText = pr.TitleText,
                                         Description   = pr.Description,
                                          CreatedDate = pr.CreatedDate,
                                          UpdatedDate = pr.UpdatedDate
                                      })
                                      .ToListAsync();

            if (contacts == null)
            {
                return NotFound();
            }
            return View(contacts);

        }
        public async Task<IActionResult> Details(string id)
        {
            var contact = await _context.ContactsInfo.FindAsync(Guid.Parse(id));

            if (contact is null) return NotFound();
            return View(contact);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var contact = await _context.ContactsInfo.FindAsync(Guid.Parse(id));
            if (contact is null) return NotFound();

            UpdateContactInfo_Dto updateContactInfo_Dto = new UpdateContactInfo_Dto()
            {
                Id = contact.Id.ToString(),
                Title = contact.Title,
                TitleText = contact.TitleText,
                Description = contact.Description,


            };



            return View(updateContactInfo_Dto);

        }
        [HttpPost]

        public async Task<IActionResult> UpdateContact( UpdateContactInfo_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isAbout = await _context.ContactsInfo.AnyAsync(ab =>
                ab.Title.ToLower().Trim() == model.Title.ToLower().Trim() && ab.Id != Guid.Parse(model.Id)
            );

            if (isAbout)
            {
                ModelState.AddModelError("FullName", "Daxil olan  melumat tekrarlanir");

            }
            ContactInfo contactInfo = new ContactInfo();
            contactInfo.Title = model.Title;
            contactInfo.TitleText = model.TitleText;
            contactInfo.Description = model.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "ContactInfo");
        }


        [HttpGet]
        public async Task<ActionResult> CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact(CreateContactInfo_Dto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ContactInfo contact = new ContactInfo()
            {
                TitleText = model.TitleText,
                Title = model.Title,
                Description = model.Description,
            };



            await _context.ContactsInfo.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "ContactInfo");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteContact(string contactId)
        {
            var contact = await _context.ContactsInfo.FirstOrDefaultAsync(c => c.Id == Guid.Parse(contactId));

            if (contact is null) return BadRequest();
            _context.ContactsInfo.Remove(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "ContactInfo");
        }
    }
}

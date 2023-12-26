using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Dto.About_Dto;
using Task_15.Models.Context;
using Task_15.Models.Dto.Contact_Dto;
using Task_15.Models.Entities;

namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        readonly private Task_15DbContext _context;
        public ContactController(Task_15DbContext context)
        {
            _context = context;
        }
        public async Task< IActionResult> Index()
        {

            var contacts = await _context.Contacts
                                      .Select(pr => new Contact()
                                      {
                                          Id = pr.Id,
                                          Telephone = pr.Telephone,
                                          FullName = pr.FullName,
                                          TitleWork= pr.TitleWork,  
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
            var contact = await _context.Contacts.FindAsync(Guid.Parse(id));

            if (contact is null) return NotFound();
            return View(contact);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var contact = await _context.Contacts.FindAsync(Guid.Parse(id));
            if (contact is null) return NotFound();

            UpdateContact_Dto updateContact_Dto = new UpdateContact_Dto()
            {
                Id = contact.Id.ToString(),
                Telephone=contact.Telephone,
                TitleWork=contact.TitleWork,
                FullName=contact.FullName,


            };



            return View(updateContact_Dto);

        }
        [HttpPost]

        public async Task<IActionResult> UpdateContact(UpdateContact_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isAbout = await _context.Contacts.AnyAsync(ab =>
                ab.FullName.ToLower().Trim() == model.FullName.ToLower().Trim()  && ab.Id != Guid.Parse(model.Id)
            );

            if (isAbout)
            {
                ModelState.AddModelError("FullName", "Daxil olan  melumat tekrarlanir");
               
            }
            Contact contact = new Contact();
            contact.FullName = model.FullName;
            contact.Telephone = model.Telephone;
            contact.TitleWork = model.TitleWork;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Contact");
        }


        [HttpGet]
        public async Task<ActionResult> CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateContact(CreateContact_Dto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Contact contact = new Contact()
            {
                TitleWork = model.TitleWork,
                FullName = model.FullName,
                Telephone = model.Telephone,
            };



            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Contact");
        }

        [HttpPost]
        public   async Task<IActionResult> DeleteContact( string contactId)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(c=>c.Id==Guid.Parse(contactId));

            if (contact is null) return BadRequest();
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Contact");
        }

    }
}

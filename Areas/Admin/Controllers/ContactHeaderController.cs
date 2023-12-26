using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Areas.Admin.Dto.ContactHeader_Dto;
using Task_15.Models.Context;
using Task_15.Models.Entities;

namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactHeaderController : Controller
    {

        readonly private Task_15DbContext _context;

        public ContactHeaderController(Task_15DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var contact = await _context.ContactHeader.ToListAsync();
           


            return View(contact);
        }

        public async Task<IActionResult> Details(string id)
        {

            var contact = await _context.ContactHeader.FindAsync(Guid.Parse(id));
            if (contact == null) return NotFound();
            return View(contact);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        => View();

        public async Task<IActionResult> Create(CreateContactHeader_Dto model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
                
            
            if (model.File == null)
            {
                ModelState.AddModelError("File", "Melumat yoxdur");
                return View(model);
            }

            if (!model.File.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("File", "Yalniz shekil fayllari qebul edilir");
                return View(model);
            }

            if (model.File.Length / 1024 >256)
            {
                ModelState.AddModelError("File", $"Hecmi {model.File.Length / 1024} kv uygun deyil");
                return View(model);
            }

            var extension = Path.GetExtension(model.File.FileName);
            var newName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", newName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.File.CopyToAsync(stream);
            }


            ContactHeader contactHeader = new ContactHeader()
            {
                Title = model.Title,
                Description = model.Description,
                Content = model.Content,
                Link = model.Link,
                FilePath = newName
            };

            await _context.ContactHeader.AddAsync(contactHeader);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {

            var contactHeader = await _context.ContactHeader.FindAsync(Guid.Parse(id));
            if (contactHeader == null) return NotFound();
            if (!ModelState.IsValid) return View(contactHeader);

            UpdateContactHeader_Dto updateContact = new UpdateContactHeader_Dto()
            {
                Id = contactHeader.Id.ToString(),
                Description = contactHeader.Description,
                Content = contactHeader.Content,
                Link = contactHeader.Link,
                FilePath = contactHeader.FilePath,
            };
            return View(updateContact);
        }

        public async Task<IActionResult> Update(UpdateContactHeader_Dto model)
        {
            if (model.File == null)
            {
                ModelState.AddModelError("File", "Melumat yoxdur");
                return View(model);
            }
            if (!model.File.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("File", "Yalniz shekil fayllari qebul edilir");
                return View(model);
            }

            if (model.File.Length / 1024 > 256)
            {
                ModelState.AddModelError("File", $"Hecmi {model.File.Length / 1024} kv uygun deyil");
                return View(model);
            }

            var extension = Path.GetExtension(model.File.FileName);
            var newName = $"{Guid.NewGuid()}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\assets\\img", newName);

            using (var stream = new FileStream(path, FileMode.CreateNew))
            {
                await model.File.CopyToAsync(stream);
            }
            ContactHeader contact = new ContactHeader();
            contact.Title = model.Title;
            contact.Description = model.Description;
            contact.Content = model.Content;
            contact.FilePath = newName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var contactid = await _context.ContactHeader.FirstOrDefaultAsync(cont => cont.Id == Guid.Parse(id));

            if (contactid == null) return BadRequest();
            _context.ContactHeader.Remove(contactid);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

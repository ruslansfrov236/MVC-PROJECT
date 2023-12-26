using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Context;
using Task_15.Models.Dto.AboutHeader_Dto;
using Task_15.Models.Entities;

namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutHeaderController : Controller
    {
        readonly private Task_15DbContext _context;

        public AboutHeaderController(Task_15DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var about = await _context.AboutHeaders.Select(ab => new AboutHeader
            {
                Id = ab.Id,
                Title = ab.Title,
                Description = ab.Description,
                FilePath = ab.FilePath,
                Url=ab.Url,
                UrlText=ab.UrlText,
               Text=ab.Text,
                CreatedDate = ab.CreatedDate,
                UpdatedDate = ab.UpdatedDate



            }).ToListAsync();

            return View(about);
        }

        public async Task<IActionResult> Details(string id)
        {
            var about = await _context.AboutHeaders.FindAsync(Guid.Parse(id));

            if (about is null) return NotFound();
            return View(about);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAboutHeader(string id)
        {
            var about = await _context.AboutHeaders.FindAsync(Guid.Parse(id));
            if (about is null) return NotFound();

            UpdateAboutHeader_Dto updateAbout_Dto = new UpdateAboutHeader_Dto()
            {
                id = about.Id.ToString(),
                Title = about.Title,
                Description = about.Description,
                FilePath = about.FilePath,
                Url=about.Url,
                UrlText=about.UrlText, 
                Text=about.Text, 
                


            };



            return View(updateAbout_Dto);

        }
        [HttpPost]

        public async Task<IActionResult> UpdateAbout(UpdateAboutHeader_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isAbout = await _context.AboutHeaders.AnyAsync(ab =>
                ab.Title.ToLower().Trim() == model.Title.ToLower().Trim() &&
                ab.Description.ToLower().Trim() == model.Description.ToLower().Trim() &&
                ab.FilePath.ToLower().Trim() == model.FilePath.ToLower().Trim() && ab.Id != Guid.Parse(model.id)
            );

            if (isAbout)
            {
                ModelState.AddModelError("FilePath", "Daxil olan  melumat tekrarlanir");
                ModelState.AddModelError("Title", "Daxil olan  melumat tekrarlanir");
                ModelState.AddModelError("Description", "Daxil olan  melumat tekrarlanir");
            }
            About about = new About();

            about.Title = model.Title;
            about.Description = model.Description;
            about.Title = model.Title;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "AboutHeader");
        }


        [HttpGet]
        public async Task<ActionResult> CreateAboutHeader()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAboutHeader(CreateAboutHeader_Dto model)
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

            if (model.File.Length / 1024 > 256)
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
            AboutHeader about = new AboutHeader()
            {
                Title = model.Title,
                Description = model.Description,
                FilePath = newName,
                Text= model.Text,
                UrlText= model.UrlText,
                Url= model.Url,
              
            };



            await _context.AboutHeaders.AddAsync(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "AboutHeader");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAboutHeader(string aboutId)
        {
            var about = await _context.AboutHeaders.FirstOrDefaultAsync(c => c.Id == Guid.Parse(aboutId));

            if (about is null) return BadRequest();
            _context.AboutHeaders.Remove(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "AboutHeader");
        }
    }
}

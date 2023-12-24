using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Areas.Admin.Dto.About_Dto;
using Task_15.Areas.Admin.Dto.AboutHeader_Dto;
using Task_15.Models.Context;
using Task_15.Models.Entities;
using Task_15.ViewsModels.About;

namespace Task_15.Controllers
{
    public class AboutController : Controller
    {

        readonly private Task_15DbContext _context;

        public AboutController(Task_15DbContext context)
        {
            _context= context;
        }

        public async Task<IActionResult> Index()
        {
           var aboutHeaders =  await _context.AboutHeaders.FirstOrDefaultAsync();
            var abouts = await _context.Abouts.ToListAsync();
         

            AboutIndexViewModel model = new AboutIndexViewModel()
            {
                AboutHeaders = aboutHeaders,
                Abouts = abouts
            };
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var about = await _context.Abouts.FindAsync(Guid.Parse(id));

            if (about is null) return NotFound();
            return View(about);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var about = await _context.Abouts.FindAsync(Guid.Parse(id));
            if (about is null) return NotFound();

            UpdateAbout_Dto updateAbout_Dto = new UpdateAbout_Dto()
            {
                Id = about.Id.ToString(),
                Title = about.Title,
                Description = about.Description,
                FilePath = about.FilePath,


            };



            return View(about);

        }
        [HttpPost]

        public async Task<IActionResult> UpdateAbout(UpdateAbout_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isAbout = await _context.AboutHeaders.AnyAsync(ab =>
                ab.Title.ToLower().Trim() == model.Title.ToLower().Trim() &&
                ab.Description.ToLower().Trim() == model.Description.ToLower().Trim() &&
                ab.FilePath.ToLower().Trim() == model.FilePath.ToLower().Trim() && ab.Id != Guid.Parse(model.Id)
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
        public async Task<ActionResult> CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAbout(CreateAbout_Dto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            About about = new About()
            {
                Title = model.Title,
                Description = model.Description,
                FilePath = model.FilePath,
              
            };



            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "AboutHeader");
        }
    }
}


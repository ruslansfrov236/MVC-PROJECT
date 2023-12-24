using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Areas.Admin.Dto.About_Dto;
using Task_15.Models.Context;
using Task_15.Models.Entities;

namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {

        readonly private Task_15DbContext _context;

        public AboutController(Task_15DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var about = await _context.Abouts.Select(ab => new About
            {
                Id = ab.Id,
                Title = ab.Title,
                Description = ab.Description,
                FilePath = ab.FilePath,
                CreatedDate = ab.CreatedDate,
                UpdatedDate = ab.UpdatedDate


            }).ToListAsync();

            return View(about);
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
            if (about == null) return NotFound();

            UpdateAbout_Dto updateAbout_Dto = new UpdateAbout_Dto()
            {
                Id = about.Id.ToString(),
                Title = about.Title,
                Description = about.Description,
                FilePath = about.FilePath,


            };



            return View(updateAbout_Dto);

        }
        [HttpPost]

        public async Task<IActionResult> UpdateAbout(UpdateAbout_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isAbout = await _context.Abouts.AnyAsync(ab =>
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

            about.Title= model.Title;
            about.Description= model.Description;
            about.Title= about.Title;
           
            await _context .SaveChangesAsync(); 
            return RedirectToAction(nameof(Index), "About");
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

         

           await  _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "About");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAbout(string aboutId)
        {
            var about = await _context.Abouts.FirstOrDefaultAsync(c => c.Id == Guid.Parse(aboutId));

            if (about is null) return BadRequest();
            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "About");
        }
    }
}

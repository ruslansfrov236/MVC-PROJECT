using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Dto.About_Dto;
using Task_15.Models.Context;
using Task_15.Models.Dto.Pricing_Dto;
using Task_15.Models.Entities;

namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PricingController : Controller
    {
        readonly private Task_15DbContext _context;

        public PricingController(Task_15DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var pricing = await _context.Pricing.Select(ab => new Pricing
            {
                Id = ab.Id,
                Title = ab.Title,
                Price = ab.Price,
                PriceCategory = ab.PriceCategory,
                PricngName= ab.PricngName,  
                PricingUser = ab.PricingUser,
                TotalMemory = ab.TotalMemory,
                CreatedDate = ab.CreatedDate,
                UpdatedDate = ab.UpdatedDate


            }).ToListAsync();
            return View(pricing);
        }

        public async Task<IActionResult> Details(string id)
        {
            var pricing = await _context.Pricing.FindAsync(Guid.Parse(id));

            if (pricing is null) return NotFound();
            return View(pricing);
        }


        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var pricing = await _context.Pricing.FindAsync(Guid.Parse(id));
            if (pricing == null) return NotFound();

            UpdatePricing_Dto updatePricing_Dto = new UpdatePricing_Dto()
            {
                Id = pricing.Id.ToString(),
                Title = pricing.Title,
                Price = pricing.Price,
                PriceCategory = pricing.PriceCategory,
                PricngName = pricing.PricngName,
                PricingUser = pricing.PricingUser,
                TotalMemory = pricing.TotalMemory,


            };



            return View(updatePricing_Dto);

        }
        [HttpPost]

        public async Task<IActionResult> Update(UpdatePricing_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            bool isAbout = await _context.Pricing.AnyAsync(ab =>
                ab.Title.ToLower().Trim() == model.Title.ToLower().Trim() &&
                ab.PriceCategory.ToLower().Trim() == model.PriceCategory.ToLower().Trim() &&
                ab.PricingUser.ToLower().Trim() == model.PricingUser.ToLower().Trim() && ab.Id != Guid.Parse(model.Id)
            );

            if (isAbout)
            {
                ModelState.AddModelError("PriceName", "Daxil olan  melumat tekrarlanir");
                ModelState.AddModelError("Title", "Daxil olan  melumat tekrarlanir");
                ModelState.AddModelError("PricingUser", "Daxil olan  melumat tekrarlanir");
            }
            Pricing pricing = new Pricing();

            pricing.Title = model.Title;
            pricing.TotalMemory = model.TotalMemory;
            pricing.PricingUser = model.PricingUser;
            pricing.PriceCategory = model.PriceCategory;
            pricing.Price = model.Price;
            pricing.PricngName = model.PricngName;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePricing_Dto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Pricing pricing = new Pricing()
            {
                Title = model.Title,

                PricingUser = model.PricingUser,
                PriceCategory = model.PriceCategory,
                Price = model.Price,
                TotalMemory = model.TotalMemory,
                PricngName = model.PricngName
            };





            await _context.Pricing.AddAsync(pricing);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), "Pricing");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string aboutId)
        {
            var pricing = await _context.Pricing.FirstOrDefaultAsync(c => c.Id == Guid.Parse(aboutId));

            if (pricing is null) return BadRequest();
            _context.Pricing.Remove(pricing);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

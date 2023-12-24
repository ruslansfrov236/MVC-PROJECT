
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Policy;
using Task_15.Models.Context;
using Task_15.Models.Entities;


namespace Task_15.Controllers
{
    public class PricingController : Controller
    {

        readonly private Task_15DbContext _context;

        public PricingController(Task_15DbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int size=1  )
        {

            var pricing = await _context.Pricing.Select(pr => new Pricing
            {
                Title = pr.Title,
                TotalMemory = pr.TotalMemory,
                Price = pr.Price,
                PriceCategory = pr.PriceCategory,
                PricingUser = pr.PricingUser,
                PricngName = pr.PricngName,
            }).Take(size).ToListAsync();


            return View(pricing);


        }
   
        public  async Task<IActionResult> Load( int size, int page=0)
        {
            var pricing = await _context.Pricing.Select(pr => new Pricing
            {
                Title = pr.Title,
                TotalMemory = pr.TotalMemory,
                Price = pr.Price,
                PriceCategory = pr.PriceCategory,
                PricingUser = pr.PricingUser,
                PricngName = pr.PricngName,
            }).Skip(page*size).Take(size).ToListAsync();


            return PartialView("_pricingPartial", pricing);
        }

    }
}

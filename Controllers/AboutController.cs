using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Context;
using Task_15.ViewsModels.About;

namespace Task_15.Controllers
{
    public class AboutController : Controller
    {

        readonly private Task_15DbContext _task_15DbContext;

        public AboutController(Task_15DbContext task_15DbContext)
        {
            _task_15DbContext = task_15DbContext;
        }

        public async Task<IActionResult> Index()
        {
           var aboutHeaders =  await _task_15DbContext.AboutHeaders.FirstOrDefaultAsync();
            var abouts = await _task_15DbContext.Abours.ToListAsync();
         

            AboutIndexViewModel model = new AboutIndexViewModel()
            {
                AboutHeaders = aboutHeaders,
                Abouts = abouts
            };
            return View(model);
        }
    }
}

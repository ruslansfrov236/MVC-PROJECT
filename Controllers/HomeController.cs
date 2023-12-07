using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Models.Context;
using Task_15.Models.Entities;
using Task_15.ViewsModels.Home;

namespace Task_15.Controllers
{
    public class HomeController : Controller
    {
        readonly private Task_15DbContext _task_15DbContext;
        public HomeController(Task_15DbContext task_15DbContext)
        {
            _task_15DbContext=task_15DbContext;
        }
        public async Task<IActionResult> Index()
        {
           var  products = await  _task_15DbContext.Products.ToListAsync();
             
           var  recents = await  _task_15DbContext.Recents.ToListAsync();

            HomeIndexViewModel model = new HomeIndexViewModel() { Products = products, Recents = recents };


            return View(model);     }  
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_15.Areas.Admin.Data.Product_Dto;
using Task_15.Models.Context;
using Task_15.Models.Entities;



namespace Task_15.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        readonly private Task_15DbContext _context;

        public object FilePath { get; private set; }

        public ProductController(Task_15DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var product = await _context.Products
                                        .Select(pr => new Product()
                                        {
                                            Id=pr.Id,   
                                            FilePath = pr.FilePath,
                                            Title = pr.Title,
                                            Text = pr.Text,
                                            CreatedDate = pr.CreatedDate,
                                            UpdatedDate = pr.UpdatedDate
                                        })
                                        .ToListAsync();

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        public async Task<ActionResult> Details(string id)
        {
            var product = await _context.Products.FindAsync(Guid.Parse(id));
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            var product= await _context.Products.FindAsync(Guid.Parse(id));

            if (product == null) return NotFound();

            UpdateProduct_Dto update = new UpdateProduct_Dto()
            {
                Id = product.Id.ToString(),
                FilePath =product.FilePath,
                Title = product.Title,
                Text=product.Text
            };




            return View(update);


        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProduct_Dto model)
        {

            var product = await _context.Products.FindAsync(Guid.Parse(model.Id));

            if (product== null) return NotFound();
            if (!ModelState.IsValid) return View(model);
            var isAny = await _context.Products.AnyAsync(i => i.FilePath.ToLower().Trim() == model.FilePath.ToLower().Trim() && i.Title.ToLower().Trim() == model.Title.ToLower().Trim() && i.Id != Guid.Parse(model.Id) && i.Id!=Guid.Parse(model.Id));
            if (isAny)
            {
                ModelState.AddModelError("FilePath", "Daxil olan  melumat tekrarlanir");
                ModelState.AddModelError("Title", "Daxil olan  melumat tekrarlanir");
                ModelState.AddModelError("Text", "Daxil olan  melumat tekrarlanir");
                return View(model);
            }

            product.FilePath = model.FilePath;
            product.Title = model.Title;
            product.Text = model.Text;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProduct_Dto model)
        {
            if (!ModelState.IsValid) return View(model);

            Product product = new Product()
            {
                FilePath = model.FilePath,
                Title = model.Title,
                Text = model.Text,
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public async Task<IActionResult> DeleteProduct(string productId)
        {

            var product = await _context.Products.FirstOrDefaultAsync(pr => pr.Id == Guid.Parse(productId));
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

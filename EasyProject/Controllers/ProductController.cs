using Microsoft.AspNetCore.Mvc;
using EasyProject.Data;
using EasyProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var product = from p in _context.Products select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Name.Contains(searchString));
            }
            return View(await product.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var product = await _context.Products
                .Include(pi => pi.ProductProperties)
                .ThenInclude(pi => pi.Properties)
                .SingleOrDefaultAsync(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}

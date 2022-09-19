using _00_Repetition_EntityFramework.Models;
using _00_Repetition_EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace _00_Repetition_EntityFramework.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _productRepository.GetAllProductsAsync();
            return View(items);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreate item)
        {
            if (ModelState.IsValid)
            {
                var product = await _productRepository.CreateProductAsync(item);
                if (product != null)
                    return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

    }
}

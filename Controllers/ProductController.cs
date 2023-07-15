using Coffee.Models;
using Coffee.Service;
using Coffee.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment hostEnvironment)
        {
            _productRepository = productRepository;
            _hostEnvironment = hostEnvironment;
        }


        public async Task<IActionResult> Index()
        {
            ProductVM productVM = new ProductVM();
            productVM.Products = await _productRepository.GetAll();
            return View(productVM);

        }

        [HttpGet]
        public async Task<IActionResult> CreateUpdate(int? id)
        {
            ProductVM vm = new ProductVM()
            {
                Product = new(),
            };
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Product = await _productRepository.GetById(id);
                if (vm.Product == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ProductVM vm, IFormFile? file)
        {

            string fileName = String.Empty;
            if (file != null)
            {
                string uploadDir = Path.Combine(_hostEnvironment.WebRootPath, "ProductImage");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                if (vm.Product.Image != null)
                {
                    var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, vm.Product.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                vm.Product.Image = @"\ProductImage\" + fileName;
            }

            if (vm.Product.Id == 0)
            {
                _productRepository.Add(vm.Product);
                TempData["success"] = "Product Created Done!";
            }
            else
            {
                _productRepository.Update(vm.Product);
                TempData["success"] = "Product Update Done!";
            }
            return RedirectToAction("Index");


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteData(int? id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productRepository.Delete(product);
            TempData["success"] = "Category Deleted Done!";
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> AllProducts()
        {
            var products = await _productRepository.GetAll();
            return View(products);
        }


        

    }
}

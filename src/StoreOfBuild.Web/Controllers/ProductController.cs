using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers {
    [Authorize(Roles= "Admin, Manager")]
    public class ProductController : Controller {
        private readonly ProductStorer _productStorer;
        private readonly IRepository<Product> _produtctRepository;
        public readonly IRepository<Category> _categoryRepository;

        public ProductController(ProductStorer productStorer,  IRepository<Product> produtctyRepository, IRepository<Category> categoryRepository) {
            _productStorer = productStorer;
            _produtctRepository = produtctyRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index () {

            var products = _produtctRepository.All();

            if(products.Any())
            {
                var viewModel = products.Select(p => new ProductViewModel{ ProductId = p.Id, Name = p.Name, CategoryName = p.Category.Name, CategoryId = p.Category.Id, Price = p.Price, StockQuantity = p.StockQuantity} );

                return View(viewModel);
            }
            return View (new List<ProductViewModel>());
        }

        public IActionResult CreateOrEdit (int id) {

            var viewModel = new ProductViewModel();
            var cateogories = _categoryRepository.All();

            if(cateogories.Any())
                viewModel.Categories = cateogories.Select(c => new CategoryViewModel{ Id = c.Id, Name = c.Name});

            if(id > 0)
            {
                var product = _produtctRepository.GetById(id);
                viewModel.ProductId = product.Id;
                viewModel.Name = product.Name;
                viewModel.CategoryId = product.Category.Id;
                viewModel.Price = product.Price;
                viewModel.StockQuantity = product.StockQuantity;
            }

            return View (viewModel);
        }

        [HttpPost]
        public IActionResult CreateOrEdit (ProductViewModel viewModel) 
        {

            _productStorer.Store(viewModel.ProductId, viewModel.Name, viewModel.CategoryId, viewModel.Price, viewModel.StockQuantity);
            return RedirectToAction("Index");
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Domain.Sales;
using StoreOfBuild.Web.ViewsModels;

namespace StoreOfBuild.Web.Controllers {
    
    [Authorize]
    public class SaleController : Controller {
        private readonly SaleFactory _saleFactory;
        private readonly IRepository<Product> _produtctRepository;

        public SaleController (SaleFactory saleFactory, IRepository<Product> produtctyRepository) {
            _saleFactory = saleFactory;
            _produtctRepository = produtctyRepository;
        }

        public IActionResult Create () 
        {

            var products = _produtctRepository.All ();

            var productView = products.Select(c => new ProductViewModel{ ProductId = c.Id, Name = c.Name});
            return View(new SaleViewModel{Products = productView});
        }

        [HttpPost]
        public IActionResult Create (SaleViewModel viewModel) {
            
            _saleFactory.Create(viewModel.ClientName, viewModel.ProductId, viewModel.Quantity);
            return Ok();
            
        }

    }
}
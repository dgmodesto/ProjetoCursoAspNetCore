using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Domain.Sales
{
    public class SaleFactory
    {
        private readonly IRepository<Sale> _saleRespository;
        private readonly IRepository<Product> _productRespository;

        public SaleFactory(IRepository<Sale> saleRespository, IRepository<Product> productRespository)
        {
            _saleRespository = saleRespository;
            _productRespository = productRespository;
        }


        public void Create(string clientName, int productId, int quantity)
        {
            var product = _productRespository.GetById(productId);
            product.RemoveFromStock(quantity);

            var sale = new Sale(clientName, product, quantity);
            _saleRespository.Save(sale);

        }


    }
}
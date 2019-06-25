
namespace StoreOfBuild.Domain.Products
{
    public class ProductStorer
    {
        private readonly IRepository<Product>  _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        public ProductStorer(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public void Store(int Id, string Name, int CategoryId, decimal  Price, int StockQuantity)
        {
            var category = _categoryRepository.GetById(CategoryId);
            DomainException.When(category == null, "Category invalid");

            var product = _productRepository.GetById(Id);
            if(product == null)
            {
                product = new Product(Name, category, Price, StockQuantity);
                _productRepository.Save(product);
            }
            else
            {
                product.Update(Name, category, Price,StockQuantity);
            }
        }
    }
}
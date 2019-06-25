
namespace StoreOfBuild.Domain.Products
{
    public class CategoryStorer
    {
        public readonly IRepository<Category> _categoryRepository;
        

        public CategoryStorer (IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Store(int id, string name)
        {
            var category = _categoryRepository.GetById(id);

            if(category == null)
            {
                category = new Category( name);
                _categoryRepository.Save(category);
            }
            else
            {
                category.Update(name);
            }
        }
    }
}
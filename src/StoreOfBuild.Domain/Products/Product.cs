namespace StoreOfBuild.Domain.Products {
    public class Product : Entity {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public virtual Category Category { get; private set; }

        public Product () {

        }
        public Product (string name, Category category, decimal price, int stockQuantity) {
            ValidateValues (name, category, price, stockQuantity);
            SetProperties (name, category, price, stockQuantity);

        }

        public void Update (string name, Category category, decimal price, int stockQuantity) {
            ValidateValues (name, category, price, stockQuantity);
            SetProperties (name, category, price, stockQuantity);
        }

        private void SetProperties (string name, Category category, decimal price, int stockQuantity) {
           
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }

        private static void ValidateValues (string name, Category category, decimal price, int stockQuantity) {
            DomainException.When (string.IsNullOrEmpty (name), "Name is require");
            DomainException.When (category == null, "Category is require");
            DomainException.When (price < 0, "Price is require");
            DomainException.When (stockQuantity < 0, "Stock Quantity is require");
        }
    
        public void RemoveFromStock (int quantity){
            DomainException.When((StockQuantity - quantity) < 0, "Quantity invalid to product stock");
            StockQuantity -= quantity;

        }
    }
}
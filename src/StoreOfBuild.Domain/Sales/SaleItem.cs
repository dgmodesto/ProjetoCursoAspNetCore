using StoreOfBuild.Domain.Products;

namespace StoreOfBuild.Domain.Sales {
    public class SaleItem : Entity
    {

        public SaleItem(){}
        public SaleItem (Product product, int quantity) {
            DomainException.When(product == null, "Product is required");
            DomainException.When(quantity < 1, "Quantity incorrect");

            Product =product;
            Quantity = quantity;
            Price = product.Price;
            Total = product.Price * Quantity;
        }
        public Product Product { get; set; }
        public decimal Price {get;set;}
        public int Quantity { get; set; }

        public decimal Total{get;set;}
    }
}
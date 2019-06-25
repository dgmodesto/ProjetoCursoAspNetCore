using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewsModels
{
    public class SaleViewModel
    {
        public int ProductId {get;set;}
        [Required]
        public string ClientName {get;set;}
        public IEnumerable<ProductViewModel> Products {get;set;}
        [Required]
        public int Quantity {get;set;}
    }
}
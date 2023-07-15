using Coffee.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Coffee.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();
        [ValidateNever]
        public IEnumerable<Product> Products { get; set; } = new List<Product>();


    }
}

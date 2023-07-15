using Coffee.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Coffee.ViewModels
{
    public class OrderVM
    {
        public Order Order { get; set; } = new Order();
        [ValidateNever]
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();

    }
}

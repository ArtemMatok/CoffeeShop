using Coffee.Repositories;
using Coffee.Service;
using Coffee.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Coffee.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            OrderVM orderVM = new OrderVM();
            orderVM.Orders = await _orderRepository.GetAll();
            return View(orderVM);   
        }


        [HttpGet]
        public IActionResult Create()
        {
            OrderVM vm = new OrderVM();
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderVM vm)
        {
            _orderRepository.Add(vm.Order);
            TempData["success"] = "Order Create Done!";
            return RedirectToAction("AllProducts","Product");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteData(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderRepository.Delete(order);
            TempData["success"] = "Category Deleted Done!";
            return RedirectToAction("Index");
        }
    }
}

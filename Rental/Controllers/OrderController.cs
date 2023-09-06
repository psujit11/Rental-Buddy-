using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Rental.Data;
using Rental.Models;

namespace Rental.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly RentalContext _context;
        private readonly Cart _cart;
        public OrderController(RentalContext context,Cart cart)
        {
            _context = context;
            _cart = cart;

        }
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is empty, please add a book first.");
            }

            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _cart.ClearCart();
                return View("CheckoutComplete", order);
            }

            return View(order);
        }
        public IActionResult CheckoutComplete(Order order)
        {
            return View(order);
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced=DateTime.Now;
            var cartItems = _cart.CartItems;
            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem()
                {
                    Quantity = item.Quantity,
                    BookId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price * item.Quantity
                };
                order.OrderItems.Add(orderItem);
                order.OrderTotal += orderItem.Price;
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }

}
   


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Rental.Data;
using Rental.Models;

namespace Rental.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly RentalContext _context;
        private readonly Cart _cart;
        

        public CartController(RentalContext context,Cart cart)
        {
            _context= context;
            _cart= cart;
        }
        public IActionResult Index()
        {
            var items = _cart.GetAllCartItems();
            _cart.CartItems =   items;
            return View(_cart);
        }
        public IActionResult AddToCart(int id)
        {
            var selectedProduct = GetProductById(id);
            if (selectedProduct != null)
            {
                _cart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index","Store");
        }
        public IActionResult RemoveFromCart(int id)
        {
            var selectedProduct = GetProductById(id);

            if (selectedProduct != null)
            {
                _cart.RemoveFromCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }
        public IActionResult ReduceQuantity(int id)
        {
            var selectedProduc = GetProductById(id);

            if (selectedProduc != null)
            {
                _cart.ReduceQuantity(selectedProduc);
            }

            return RedirectToAction("Index");
        }

        public IActionResult IncreaseQuantity(int id)
        {
            var selectedProduct = GetProductById(id);

            if (selectedProduct != null)
            {
                _cart.IncreaseQuantity(selectedProduct);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cart.ClearCart();

            return RedirectToAction("Index");
        }
        public Product GetProductById(int id) => _context.Products.FirstOrDefault(b => b.Id == id);
      
    }
}

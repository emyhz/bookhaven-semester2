using LogicLayer.Algorithm;
using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    public class CartModel : PageModel
    {
        private UserManager _userManager;
        private OrderItemManager _orderItemManager;
        private DiscountManager _discountManager;

        public CartModel(UserManager userManager, OrderItemManager orderItemManager, DiscountManager discountManager)
        {
            _userManager = userManager;
            _orderItemManager = orderItemManager;
            _discountManager = discountManager;
        }

        //properties
        public List<OrderItem> OrderItems { get; set; }
        public int TotalOrderItems { get; set; }

        public decimal ItemsTotal { get; set; } // Total for items
        public decimal ShippingTotal { get; set; } // Total for shipping



        public IActionResult OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                User user = _userManager.GetUserByEmail(User.Identity.Name);
                OrderItems = _orderItemManager.GetUserCart(user.Id);

                foreach (var orderItem in OrderItems)
                {
                    _discountManager.ApplyDiscountForInactiveUsers(user.Id, new List<Book> { orderItem.Book });
                }


                // Calculate totals
                ItemsTotal = CartCalculation.CalculateOrderTotal(OrderItems); // Total price of items
                ShippingTotal = CartCalculation.CalculateOrderShipping(OrderItems); // Shipping cost


                TotalOrderItems = _orderItemManager.GetItemQuantityFromUser(user.Id);




                return Page();
            }
            else
            {
                return NotFound();
            }
        }
        public IActionResult OnPostIncreaseQuantity(int orderItemId)
        {
            _orderItemManager.IncreaseQuantity(orderItemId);
            return RedirectToPage();
        }
        public IActionResult OnPostDecreaseQuantity(int orderItemId)
        {
            _orderItemManager.DecreaseQuantity(orderItemId);
            return RedirectToPage();
        }

        public IActionResult OnPostRemoveItem(int orderItemId)
        {
            _orderItemManager.RemoveAudioItemFromCart(orderItemId);
            return RedirectToPage();
        }
    }
}

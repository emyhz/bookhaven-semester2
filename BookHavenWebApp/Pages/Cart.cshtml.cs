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

        public CartModel(UserManager userManager, OrderItemManager orderItemManager)
        {
            _userManager = userManager;
            _orderItemManager = orderItemManager;
        }

        //properties
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalOrderItems { get; set; }


        public IActionResult OnGet()
        {
            if(User.Identity.IsAuthenticated)
            {
                User user = _userManager.GetUserByEmail(User.Identity.Name);
                //OrderItems = _orderItemManager.
                TotalPrice = CartCalculation.CalculateTotal(OrderItems);
                //TotalOrderItems = _orderItemManager



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
    }
}

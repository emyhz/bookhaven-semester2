using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BookHavenWebApp.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly UserManager _userManager;
        private readonly OrderItemManager _orderItemManager;
        private readonly OrderManager _orderManager;
        private readonly BookManager _bookManager;

        public CheckoutModel(UserManager userManager, OrderItemManager orderItemManager, OrderManager orderManager, BookManager bookManager)
        {
            _userManager = userManager;
            _orderItemManager = orderItemManager;
            _orderManager = orderManager;
            _bookManager = bookManager;
        }

        public User user { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int TotalPrice { get; set; }
        public int TotalCartQuantity { get; set; }

        [BindProperty]
        [Required]
        public string Address { get; set; }

        [BindProperty]
        [Required]
        public string Country { get; set; }

        [BindProperty]
        [Required]
        public string City { get; set; }

        [BindProperty]
        [Required]
        public string ZipCode { get; set; }

        [BindProperty]
        [Required]
        public string CardNumber { get; set; }

        [BindProperty]
        [Required]
        public string CardHolderName { get; set; }

        [BindProperty]
        [Required]
        public string ExpiryDate { get; set; }

        [BindProperty]
        [Required]
        public string CVV { get; set; }


        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);
                OrderItems = _orderItemManager.GetUserCart(user.Id);
                //TotalPrice = CartCalculation.CalculateTotal(OrderItems);
                TotalCartQuantity = _orderItemManager.GetItemQuantityFromUser(user.Id);

                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult OnPost()
        {
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);
                OrderItems = _orderItemManager.GetUserCart(user.Id);
                //TotalPrice = CartCalculation.CalculateTotal(OrderItems);
                TotalCartQuantity = _orderItemManager.GetItemQuantityFromUser(user.Id);

            }
            else
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            int orderId = _orderManager.CreateOrder(user.Id, Address, Country, City, ZipCode, TotalPrice, 0);

            foreach (OrderItem item in OrderItems)
            {

            }
            return RedirectToPage("/CheckoutSuccess", new { orderId = orderId });

        }
    }
}

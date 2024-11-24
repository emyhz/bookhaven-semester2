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
        public decimal TotalPrice { get; set; }
        public int TotalCartQuantity { get; set; }
        //public decimal Shipping { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Address is required.")]
        public string Address { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="Country is required.")]
        public string Country { get; set; }

        [BindProperty]
        [Required(ErrorMessage ="City is required.")]
        public string City { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Zipcode is required.")]
        public string ZipCode { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Card number is required.")]
        public string CardNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Card holder is required.")]
        public string CardHolderName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Expiry date number is required.")]
        public string ExpiryDate { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "CVV is required.")]
        public string CVV { get; set; }


        public IActionResult OnGet()
        {
            //Shipping = 0.50m;

            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);
                OrderItems = _orderItemManager.GetUserCart(user.Id);
                TotalPrice = CartCalculation.CalculateOrderShipping(OrderItems);
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
                TotalPrice = CartCalculation.CalculateOrderShipping(OrderItems);
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

            int orderId = _orderManager.CreateOrder(user.Id, Address, Country, City, ZipCode, TotalPrice);

            foreach (OrderItem item in OrderItems)
            {

                _orderItemManager.Checkout(item.Id, orderId);
                _bookManager.BuyBook(item.Book.Id, item.Quantity);

            }
            return RedirectToPage("/OrderComplete", new { orderId = orderId });

        }
    }
}

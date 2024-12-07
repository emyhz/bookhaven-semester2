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
        public decimal Shipping { get; set; }

        [BindProperty]
        public bool UseOldAddress { get; set; }

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


                // Check if the user chose to use their old address
                var lastOrder = _orderManager.GetLastUsedAddress(user.Id);
                if (lastOrder != null)
                {
                    // Retrieve the last used address and populate address fields
                    Address = lastOrder.Address;
                    Country = lastOrder.Country;
                    City = lastOrder.City;
                    ZipCode = lastOrder.ZipCode;
                }



                OrderItems = _orderItemManager.GetUserCart(user.Id);
                TotalPrice = CartCalculation.CalculateOrderShipping(OrderItems);
                //Shipping =
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
                //Shipping = 
                TotalPrice = CartCalculation.CalculateOrderShipping(OrderItems);
                TotalCartQuantity = _orderItemManager.GetItemQuantityFromUser(user.Id);

            }
            else
            {
                return NotFound();
            }

            // Check if the user chose to use their previously saved address
            if (UseOldAddress)
            {
                var lastOrder = _orderManager.GetLastUsedAddress(user.Id);
                if (lastOrder != null)
                {
                    Address = lastOrder.Address;
                    Country = lastOrder.Country;
                    City = lastOrder.City;
                    ZipCode = lastOrder.ZipCode;
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //create new order
            int orderId = _orderManager.AddOrder(user.Id, Address, Country, City, ZipCode, TotalPrice);

            foreach (OrderItem item in OrderItems)
            {
                //checks book out and updates stock
                _orderItemManager.Checkout(item.Id, orderId);
                _bookManager.BuyBook(item.Book.Id, item.Quantity);

            }
            // Redirect the user to the "Order Complete" page with the order ID
            return RedirectToPage("/OrderComplete", new { orderId = orderId });

        }
    }
}

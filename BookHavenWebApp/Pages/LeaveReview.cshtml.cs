using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace BookHavenWebApp.Pages
{
    public class LeaveReviewModel : PageModel
    {
        private OrderManager _orderManager;
        private BookManager _bookManager;
        private ReviewManager _reviewManager;
        private UserManager _userManager;

        public LeaveReviewModel(OrderManager orderManager, BookManager bookManager, ReviewManager reviewManager, UserManager userManager)
        {
            _orderManager = orderManager;
            _bookManager = bookManager;
            _reviewManager = reviewManager;
            _userManager = userManager;
        }

        public Order order { get; set; }
        public Book book { get; set; }
        public User user { get; set; }

        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string? Title { get; set; }

        [BindProperty]
        public string? Comment { get; set; }

        public IActionResult OnGet(int orderId, int bookId)
        {
            if (User.Identity.IsAuthenticated)
            {
                user = _userManager.GetUserByEmail(User.Identity.Name);

                // Retrieve the order and validate it's delivered
                order = _orderManager.GetOrderDetailsForUser(orderId);
                if (order == null || order.OrderStatus != OrderStatus.DELIVERED)
                {
                    TempData["ErrorMessage"] = "You can only leave a review for delivered orders.";
                    return RedirectToPage("/Account");
                }

                // Retrieve the book details
                book = _bookManager.GetBookById(bookId);
                if (book == null)
                {
                    TempData["ErrorMessage"] = "The book you're trying to review does not exist.";
                    return RedirectToPage("/Account");
                }

                return Page();
            }

            return RedirectToPage("/Login");
        }
        public IActionResult OnPost(int orderId, int bookId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["ErrorMessage"] = "You must be logged in to leave a review.";
                return RedirectToPage("/Login");
            }

            user = _userManager.GetUserByEmail(User.Identity.Name);

            // Validate the order again during the POST request
            order = _orderManager.GetOrderDetailsForUser(orderId);
            if (order == null || order.OrderStatus != OrderStatus.DELIVERED)
            {
                TempData["ErrorMessage"] = "You can only leave a review for delivered orders.";
                return RedirectToPage("/Account");
            }

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please provide a valid rating.";
                return Page();
            }

            _reviewManager.AddReview(user.Id, bookId, Rating, Title, Comment);

            TempData["SuccessMessage"] = "Thank you for leaving a review!";
            return RedirectToPage("/Account");
        }
    }
}

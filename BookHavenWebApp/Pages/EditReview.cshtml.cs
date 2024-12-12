using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    public class EditReviewModel : PageModel
    {
        private readonly ReviewManager _reviewManager;
        public EditReviewModel(ReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        [BindProperty]
        public int ReviewId { get; set; }
        [BindProperty]
        public int Rating { get; set; }
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Comment { get; set; }

        public string BookTitle { get; set; }

        public IActionResult OnGet(int reviewId)
        {
            var review = _reviewManager.GetReviewDetails(reviewId);
            if (review == null)
            {
                return NotFound();
            }

            ReviewId = review.Id;
            Rating = review.Rating;
            Title = review.Title;
            Comment = review.Comment;
            BookTitle = review.Book.Title;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _reviewManager.UpdateReview(ReviewId, Rating, Title, Comment);
                TempData["SuccessMessage"] = "Review updated successfully!";
                return RedirectToPage("/Account");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Failed to update the review: {ex.Message}";
                return Page();
            }
        }
    }
}

using LogicLayer.EntityClasses;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookManager _bookManager;

        public IndexModel(BookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public List<Book> BestsellingBooks { get; set; }


        public void OnGet()
        {
            BestsellingBooks = _bookManager.GetBestSellingBooks(3);
        }
    }
}

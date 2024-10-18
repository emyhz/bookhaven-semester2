using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookHavenWebApp.Pages
{
    public class BooksModel : PageModel
    {
        private readonly BookManager _bookManager;
        public BooksModel(BookManager bookManager)
        {
            _bookManager = bookManager;
        }

        public List<Book> Books { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public string Author { get; set; }
        [BindProperty]
        public long ISBN { get; set; }
        [BindProperty]
        public DateTime PublishDate { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public Genre genre { get; set; }
        [BindProperty]
        public string Language { get; set; }
        [BindProperty]
        public string ImagePath { get; set; }
        [BindProperty]
        public int Stock { get; set; }


        public async Task OnGetAsync(int currentPage = 1)
        {
            int pageSize = 16;

            // Fetch all books (both AudioBooks and PhysicalBooks)
            var books = _bookManager.GetAllPhysicalBooks().Cast<Book>().Concat(_bookManager.GetAllAudioBooks().Cast<Book>()).ToList();

            // Pagination logic
            CurrentPage = currentPage;

            //all books displayed even if last page has fewer books
            TotalPages = (int)Math.Ceiling(books.Count / (double)pageSize);

            // Get books for the current page by skipping previous pages and taking 'pageSize' items.
            Books = books.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

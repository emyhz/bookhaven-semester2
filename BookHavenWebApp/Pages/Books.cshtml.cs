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
        public string Filter { get; set; }

        public async Task OnGetAsync(int currentPage = 1, string sortBy = "")
        {
            int pageSize = 16;
            var books = _bookManager.GetAllBooks();

            

            CurrentPage = currentPage;

            // Total number of pages according to number of books and page size
            TotalPages = (int)Math.Ceiling(books.Count / (double)pageSize);

 
            Books = books.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

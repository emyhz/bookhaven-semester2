using LogicLayer.Algorithm;
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
        private readonly DiscountManager _discountManager;
        private readonly UserManager _userManager;
        public BooksModel(BookManager bookManager, DiscountManager discountManager, UserManager userManager)
        {
            _bookManager = bookManager;
            _discountManager = discountManager;
            _userManager = userManager;
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
        public decimal DiscountPrice { get; set; }
        [BindProperty]
        public Genre genre { get; set; }
        [BindProperty]
        public string Language { get; set; }
        [BindProperty]
        public string ImagePath { get; set; }
        [BindProperty]
        public int Stock { get; set; }
        public string Filter { get; set; }

        public async Task OnGetAsync(int currentPage = 1, string filter = "")
        {

            int pageSize = 16;
            Filter = filter;
            var books = _bookManager.GetAllBooks();


            // Apply filter
            if (!string.IsNullOrEmpty(Filter))
            {
                List<Book> filteredBooks = new List<Book>();

                if (Filter == "Physical")
                {
                    foreach (var book in books)
                    {
                        if (book is PhysicalBook)
                        {
                            filteredBooks.Add(book);
                        }
                    }
                }
                else if (Filter == "Audio")
                {
                    foreach (var book in books)
                    {
                        if (book is AudioBook)
                        {
                            filteredBooks.Add(book);
                        }
                    }
                }

                books = filteredBooks;
            }




            // Apply discounts if the user is logged in
            if (User.Identity.IsAuthenticated)
            {
                 var user = _userManager.GetUserByEmail(User.Identity.Name);
                _discountManager.ApplyDiscountForInactiveUsers(user.Id ,books);
            }





            CurrentPage = currentPage;

            // Total number of pages according to number of books and page size
            TotalPages = (int)Math.Ceiling(books.Count / (double)pageSize);

 
            Books = books.Skip((CurrentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

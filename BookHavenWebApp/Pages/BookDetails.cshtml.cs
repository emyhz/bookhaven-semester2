using LogicLayer.EntityClasses;
using LogicLayer.Enums;
using LogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookHavenWebApp.Pages
{
    public class BookDetailsModel : PageModel
    {
        private readonly BookManager _bookManager;
        public BookDetailsModel(BookManager bookManager)
        {
            _bookManager = bookManager;
        }
        //properties to hold book details
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
        public string Language { get; set; }
        public string ImagePath { get; set; }
        public int Stock { get; set; }

        //property to hold physical details
        public string dimensions { get; set; }
        public int pages { get; set; }
        public string coverType { get; set; }

        //property to hold audio details
        public TimeSpan AudioLength { get; set; }
        public string FileSize { get; set; }

        //get all books
        public List<Book> Books { get; set; }
        public List<Book> SimilarBoughtBooks { get; set; }

        public IActionResult OnGet(int id)
        {
            //get all books
            Books = _bookManager.GetAllBooks();

            //get book by id
            Book book = _bookManager.GetBookById(id);

            //get similar bought books
            //SimilarBoughtBooks = _bookManager.GetSimilarBoughtBooks(book);

            //assign book details to properties
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            ISBN = book.ISBN1;
            PublishDate = book.PublishYear;
            Price = book.Price;
            Genre = book.Genre;
            Language = book.Language;
            ImagePath = book.ImagePath;
            Stock = book.Stock;

            //assign physical details to properties
            if (book is PhysicalBook)
            {
                PhysicalBook physicalBook = (PhysicalBook)book;
                dimensions = physicalBook.Dimensions;
                pages = physicalBook.Pages;
                coverType = physicalBook.CoverType;
            }

            //assign audio details to properties
            if (book is AudioBook)
            {
                AudioBook audioBook = (AudioBook)book;
                AudioLength = audioBook.AudioLength;
                FileSize = audioBook.FileSize;
            }

            return Page();
        }
    }
}

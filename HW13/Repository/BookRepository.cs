using HW13.DB;
using HW13.Entities;
using HW13.Enums;
using Microsoft.EntityFrameworkCore;

namespace HW13.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context = new AppDbContext();
        public void ChangeBookStatus(int bookId, Bookstatus status, int userId)
        {
            var Book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (status == Bookstatus.Borrowd)
            {
                Book.BorrowedDate = DateTime.Now;
                Book.UserId = userId;
            }
            else
            {
                Book.BorrowedDate =null;
                Book.UserId = null;
            }
            
            Book.Status = status;
            _context.SaveChanges();
        }

        public List<Book>? GetAllBorrowed(int userId)
        {
            var Books = _context.Books.AsNoTracking().Where(t => t.UserId == userId)
            .OrderBy(t => t.BorrowedDate)
            .ToList();
            return Books;

        }

        public List<Book>? GetAllAvalaibles()
        {
            var Books = _context.Books.AsNoTracking().Where(b=> b.Status == Bookstatus.Accessible).ToList();
            return Books;
        }

        public bool CheckBookAvailable(int Id)
        {
            var Book = _context.Books.AsNoTracking().Any(b => b.Id == Id && b.Status == Bookstatus.Accessible);
            return Book;
        }

        public bool GetByBookDetails(string Title, string Author, string Publisher)
        {
            var Exist = _context.Books.AsNoTracking().Any(b => b.Title == Title && b.Author ==Author && b.Publisher == Publisher);
            return Exist;
        }

        public List<Book>? GetAllBooks()
        {
           var Books = _context.Books.AsNoTracking().ToList();
            return Books;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
    }
}

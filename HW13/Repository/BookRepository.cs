using HW13.DB;
using HW13.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW13.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context = new AppDbContext();
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void BorrowBook(int bookId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public List<Book>? GetAll(int Id)
        {
            var Books = _context.Books.AsNoTracking().ToList();
            return Books;
        }

        public Book? GetById(int Id, int userId)
        {
            var Book = _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == Id && b.UserId ==userId);
            return Book;
        }

        public Book GetByTitle(string Title, int userId)
        {
            var Book = _context.Books.AsNoTracking().FirstOrDefault(b => b.Title == Title && b.UserId == userId);
            return Book;
        }

        //public List<Book> Search(string Title)
        //{
        //    var Result = _context.Books.Where(t => t.Title.Contains(Title)).ToList();
        //    return Result;
        //}

        public void Update(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}

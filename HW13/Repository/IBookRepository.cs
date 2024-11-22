using HW13.Entities;
using HW13.Enums;
namespace HW13.Repository
{
    public interface IBookRepository
    {
        public void Add(Book book);
        List<Book>? GetAllBorrowed(int userId);
        List<Book>? GetAllAvalaibles();
        public bool GetByBookDetails(string Title, string Author, string Publisher);
        bool CheckBookAvailable(int Id);
        void ChangeBookStatus(int bookId, Bookstatus status, int userId);
        List<Book>? GetAllBooks();


    }
}

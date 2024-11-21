using HW13.Entities;

namespace HW13.Repository
{
    public interface IBookRepository
    {
        List<Book>? GetAll(int Id);
        Book? GetByTitle(string Title, int userId);
        Book? GetById(int Id, int UserId);
        void Add(Book book);
        void Delete(Book book);
        void Update(int id, Book book);
        void BorrowBook(int bookId);
        //List<Book>? Search(string Title);


    }
}

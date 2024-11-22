using HW13.Entities;
using HW13.Enums;
namespace HW13.BookService;

public interface IUserService
{
    bool BorrowBook(int userId, int bookId);
    bool GiveBackBook(int userId, int bookId);
    bool ShowAllBorrowedBooks(int userId);
    bool ShowAllAvailbleBooks();
    bool LogIn(string userName, string Pass);
    bool Register(User user);
    //void SearchByTitle();
}

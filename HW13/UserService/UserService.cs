using HW13.Entities;
using HW13.Enums;
using HW13.Repository;

namespace HW13.BookService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository = new UserRepository();
    
    private readonly IBookRepository _bookRepository = new BookRepository();
    public static Admin? OnlineAdmin { get; set; }
    public static User? OnlineUser { get; set; }
    public bool LogIn(string userName, string Pass)
    {
        var CurrentAdmin = _userRepository.GetAdmin(userName, Pass);
        if (CurrentAdmin is not null)
        {
            OnlineAdmin = CurrentAdmin; 
            return true;
        }

        var CurrentUser = _userRepository.GetUser(userName, Pass);
        if (CurrentUser is not null)
        {
            OnlineUser = CurrentUser; 
            return true;
        }

        return false;
    }
    public bool ShowAllAvailbleBooks()
    {
        var Books = _bookRepository.GetAllAvalaibles();
        if (Books is null)
        {
            return false;
        }
        foreach (var b in Books)
        {
            Console.WriteLine(b.ToString());
        }
        return true;
    }

    public bool ShowAllBorrowedBooks(int userId)
    {
        var Books = _bookRepository.GetAllBorrowed(userId);
        if(Books is null)
        {
            return false;
        }
        foreach (var b in Books)
        {
            Console.WriteLine(b.ToString());
        }
        return true;
    }

    public bool BorrowBook(int userId,int bookId)
    {
        var user = _userRepository.GetUserById(userId);
        if (user == null || user.License < DateTime.Now)
        {
            Console.WriteLine("Your membership has expired. Please renew your membership.");
            return false;
        }
        var bookAvailble = _bookRepository.CheckBookAvailable(bookId);
        if (!bookAvailble)
        { 
            return false;
        }
        var status = Bookstatus.Borrowd;
        _bookRepository.ChangeBookStatus(bookId, status, userId);
        return true;
    }

    public bool Register(User user)
    {
        var existUser = _userRepository.CheckUserExist(user.UserName);
        if (existUser)
        {
            return false;
        }

        user.License = DateTime.Now.AddDays(30);
        _userRepository.AddUser(user);
        return true;
    }

    public bool GiveBackBook(int userId, int bookId)
    {

        bool notExistBook = _bookRepository.CheckBookAvailable(bookId);
        if (notExistBook)
        {
            return false;
        }
        var status = Bookstatus.Accessible;
        _bookRepository.ChangeBookStatus(bookId, status, userId);
        return true;
    }

}

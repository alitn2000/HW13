using HW13.Entities;
using HW13.Repository;

namespace HW13.AdminService;

public class AdminService : IAdminService
{
    private readonly IBookRepository _bookRepository = new BookRepository();
    private readonly IUserRepository _userRepository = new UserRepository();

    public void AddBook(Book book)
    {
        _bookRepository.Add(book);
    }

    public bool CheckBookExist(string Title, string Author, string Publisher)
    {
        bool Exist = _bookRepository.GetByBookDetails(Title, Author,Publisher);
        if(Exist)
        {
            return true;
        }
        return false;
    }

    public bool IncreaseLicense(int userId, int Days)
    {
        var user = _userRepository.GetUserById(userId);
        if (user == null)
        {
            Console.WriteLine("User not found!");
            return false;
        }
        if (user.License <= DateTime.Now)
        {
            user.License = DateTime.Now.AddDays(Days);
        }
        else
        {
            user.License = user.License.AddDays(Days);
        }

        _userRepository.UpdateUserLicense(user);
        Console.WriteLine($"License increased to: {user.License}");
        return true;
    }

    public bool ShowBooks()
    {
        var Books = _bookRepository.GetAllBooks();
        if (Books == null)
        {
            return false;
        }

        foreach (var book in Books)
        {
            Console.WriteLine($"{book.Title}:\n Status ->{book.Status} \nBorrowedDate: {book.BorrowedDate}\n----------------------------------------------------------");
        }
        return true;

    }

    public bool ShowUsers()
    {
        var Users = _userRepository.GetAllUsers();
        if (Users == null && Users.Count() == 0)
        {
            return false;
        }

        foreach (var user in Users)
        {
            Console.WriteLine(user.ToString());
        }
        return true;
    }
}

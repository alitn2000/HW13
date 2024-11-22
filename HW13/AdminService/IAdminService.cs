using HW13.Entities;

namespace HW13.AdminService;

public interface IAdminService
{
    bool ShowBooks();
    bool ShowUsers();
    bool CheckBookExist(string Title, string Author, string Publisher);
    void AddBook(Book book);
    bool IncreaseLicense(int userId, int additionalDays);
}

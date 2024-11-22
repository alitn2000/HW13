
using HW13.Entities;

namespace HW13.Repository;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUser(string userName, string Pass);
    Admin GetAdmin(string userName, string Pass);
    List<User>? GetAllUsers();
    bool CheckUserExist(string userName);
    User GetUserById(int userId);
    void UpdateUserLicense(User user);
}

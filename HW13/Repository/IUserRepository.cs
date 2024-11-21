
using HW13.Entities;

namespace HW13.Repository;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUser(string userName, string Pass);
    List<User> GetAllUsers();
    bool CheckUserExist(string userName);
}

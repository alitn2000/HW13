using HW13.DB;
using HW13.Entities;

namespace HW13.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context = new AppDbContext();
    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public User GetUser(string userName, string Pass)
    {
        var user = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == Pass);
        return user;
    }
    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public bool CheckUserExist(string userName)
    {
        var Flag = _context.Users.Any(x => x.UserName == userName);
        return Flag;
    }
}

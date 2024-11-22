using HW13.DB;
using HW13.Entities;
using Microsoft.EntityFrameworkCore;

namespace HW13.Repository;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context = new AppDbContext();
    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    public Admin GetAdmin (string userName, string Pass)
    {
        var admin = _context.Admins.AsNoTracking().FirstOrDefault(x => x.UserName == userName && x.Password == Pass);
        return admin;
    }
    public User GetUser(string userName, string Pass)
    {
        var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.UserName == userName && x.Password == Pass);
        return user;
    }
    public bool CheckUserExist(string userName)
    {
        var Flag = _context.Users.Any(x => x.UserName == userName);
        return Flag;
    }

    public List<User>? GetAllUsers()
    {
        var Users = _context.Users.AsNoTracking().ToList();
        return Users;
    }

    public User GetUserById(int userId)
    {
        var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == userId);
        return user;
    }

    public void UpdateUserLicense(User user)
    {
        var existingUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.License = user.License;
            _context.SaveChanges();
        }
    }
}

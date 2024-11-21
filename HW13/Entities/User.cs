using System.ComponentModel.DataAnnotations;

namespace HW13.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
}

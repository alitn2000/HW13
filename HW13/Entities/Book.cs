using HW13.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW13.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
    public Bookstatus Status { get; set; }  = Bookstatus.Accessible;
    public DateTime? BorrowedDate { get; set; }
    public User User { get; set; } = new User();
    public int UserId { get; set; }

    public override string ToString()
    {
        return $"{Title} : \nAuthor : {Author} \nPublisher : {Publisher} \n Price {Price} \n-----------------------------------------";
    }
}

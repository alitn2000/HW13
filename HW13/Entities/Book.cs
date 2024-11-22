using HW13.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW13.Entities;

public class Book
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    [MaxLength(100)]
    public string Author { get; set; }
    [Required]
    [MaxLength(100)]
    public string Publisher { get; set; }
    [Required]
    [MaxLength(100)]
    public decimal Price { get; set; }
    public Bookstatus Status { get; set; }  = Bookstatus.Accessible;
    public DateTime? BorrowedDate { get; set; }
    public User User { get; set; }
    public int? UserId { get; set; }

    public override string ToString()
    {
        return $"{Id}.{Title} : \nAuthor : {Author} \nPublisher : {Publisher} \n Price : {Price}\nBorrowedTime : {BorrowedDate} \n-----------------------------------------";
    }
}

using System.ComponentModel.DataAnnotations;

namespace HW13.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(100)]
    public string NationalCode { get; set; }
    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(100)]
    public string Password { get; set; }
    public DateTime License { get; set; }
    public List<Book> Books { get; set; }
    public override string ToString()
    {
        string borrowedBooks = "No borrowed books";
        if (Books != null && Books.Count > 0)
        {
            borrowedBooks = "";
            foreach (var book in Books)
            {
                borrowedBooks += $"- {book.Title} by {book.Author} (Borrowed on: {book.BorrowedDate?.ToString("yyyy-MM-dd") ?? "N/A"})\n";
            }
        }

        return $"{Id}. {UserName} ({License}):\n" +
               $"FirstName -> {FirstName}\n" +
               $"LastName -> {LastName}\n" +
               $"NationalCode -> {NationalCode}\n" +
               $"Password -> {Password}\n" +
               $"Books:\n{borrowedBooks}" +
               "----------------------------------------";
    }
}

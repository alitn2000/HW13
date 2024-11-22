using System.ComponentModel.DataAnnotations;

namespace HW13.Entities;

public class Admin
{
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}

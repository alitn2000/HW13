
using Microsoft.EntityFrameworkCore;
using HW13.InferaStructure;
using HW13.Entities;
namespace HW13.DB;

public class AppDbContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionStrings.Connection.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfig());
        modelBuilder.ApplyConfiguration(new BookConfig());

        //modelBuilder.ApplyConfiguration(new AdminConfig());
    }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}

using HW13.Entities;
using HW13.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW13.InferaStructure;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(a => a.Id);


        //builder.HasOne(b => b.User)
        //    .WithMany(b => b.Books).HasForeignKey(b => b.UserId);

        builder.HasData(

            new Book { Id = 1, Title = "AnnaKarenina", Author = "Tolstoy", Publisher = "A", Price = 120,Status =Bookstatus.Accessible,UserId =1 },
            new Book { Id = 2, Title = "War&Peace", Author = "Tolstoy", Publisher = "B", Price = 140, Status = Bookstatus.Accessible, UserId = 1 },
            new Book { Id = 3, Title = "TheBrothersOfKaramazov", Author = "Dostoevsky", Publisher = "C", Price = 200, Status = Bookstatus.Accessible,UserId = 1 },
            new Book { Id = 4, Title = "TheGambler", Author = "Dostoevsky", Publisher = "D", Price = 90, Status = Bookstatus.Accessible,UserId = 1 }
            );



    }
}

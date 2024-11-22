using HW13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HW13.InferaStructure
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);


            builder.HasData(
                new User { Id = 1, FirstName = "ali", LastName = "tahmasebinia", UserName = "alitn2000", Password = "123", NationalCode = "1234567890",License = new DateTime(2024, 11, 22, 0, 0, 0) },
                new User { Id = 2, FirstName = "reza", LastName = "rezaei", UserName = "user1", Password = "123", NationalCode = "1234567790", License = new DateTime(2024, 11, 10, 0, 0, 0) },
                new User { Id = 3, FirstName = "sara", LastName = "saraei", UserName = "user2", Password = "123", NationalCode = "1114567890", License = new DateTime(2024, 11, 22, 0, 0, 0) }
                );

        }
    }
}

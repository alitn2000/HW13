using HW13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW13.InferaStructure;

public class AdminConfig : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.HasKey(a => a.Id);


        builder.HasData(
              new Admin {Id = 1,UserName = "admin", Password = "admin" },
              new Admin {Id = 2,UserName = "admin1", Password = "admin1" }
            );
       
    }
}

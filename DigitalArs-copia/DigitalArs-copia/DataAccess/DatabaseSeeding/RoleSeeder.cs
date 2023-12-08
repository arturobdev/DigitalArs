using DigitalArs_copia.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DigitalArs_copia.DataAccess.DatabaseSeeding
{
    public class RoleSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Administrator",
                    Description = "Administrator",

                },
                 new Role
                 {
                     Id = 2,
                     Name = "Consultant",
                     Description = "Consultant",
                 });
        }
    }
}

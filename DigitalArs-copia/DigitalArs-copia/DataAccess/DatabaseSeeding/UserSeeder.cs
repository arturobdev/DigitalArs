using DigitalArs_copia.Entities;
using DigitalArs_copia.Helper;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DigitalArs_copia.DataAccess.DatabaseSeeding
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
              new User
              {
                  Id = 1,
                  FirstName = "Pablo",
                  LastName = "Ortiz",
                  Email = "adm@gmail.com", // Provide an email address
                  Password = PasswordEncryptHelper.EncryptPassword("123", "adm@gmail.com"),
                  RoleId = 1
              },
              new User
              {
                  Id = 2,
                  FirstName = "Kevin",
                  LastName = "Johnson",
                  Email = "noadm@gmail.com", // Provide an email address
                  Password = PasswordEncryptHelper.EncryptPassword("123", "noadm@gmail.com"),
                  RoleId = 2
              },
              new User
              {
                  Id = 3,
                  FirstName = "Bob",
                  LastName = "Smith",
                  Email = "bob@example.com", // Provide an email address
                  Password = PasswordEncryptHelper.EncryptPassword("123", "bob@example.com"),
                  RoleId = 1
              },
              new User
              {
                  Id = 4,
                  FirstName = "Eva",
                  LastName = "Lee",
                  Email = "eva@example.com", // Provide an email address
                  Password = PasswordEncryptHelper.EncryptPassword("123", "eva@example.com"),
                  RoleId = 2
              },
              new User
              {
                  Id = 5,
                  FirstName = "John",
                  LastName = "Doe",
                  Email = "john@example.com", // Provide an email address
                  Password = PasswordEncryptHelper.EncryptPassword("123", "john@example.com"),
                  RoleId = 2
              }
          );
        }
    }
}

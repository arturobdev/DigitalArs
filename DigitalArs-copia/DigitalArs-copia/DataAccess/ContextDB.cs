using DigitalArs_copia.DataAccess.DatabaseSeeding;
using DigitalArs_copia.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalArs_copia.DataAccess
{
    public class ContextDB : DbContext
    {
            public ContextDB(DbContextOptions options) : base(options)
            { }

            public DbSet<Account> Accounts { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            var seeders = new List<IEntitySeeder>
                {
                    new UserSeeder(),
                    new AccountSeeder(),
                    new RoleSeeder(),
                };

            foreach(var seeder in  seeders)
            {
                seeder.SeedDataBase(modelBuilder);     
            }
                base.OnModelCreating(modelBuilder);
            }
        }
    
}

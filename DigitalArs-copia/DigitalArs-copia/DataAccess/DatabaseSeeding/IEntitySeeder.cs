using Microsoft.EntityFrameworkCore;

namespace DigitalArs_copia.DataAccess.DatabaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDataBase(ModelBuilder moderBuilder);
    }
}

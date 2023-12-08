using DigitalArs_copia.DataAccess.Repositories;

namespace DigitalArs_copia.Services
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }

        public AccountRepository AccountRepository { get; }

        public RoleRepository RoleRepository { get; }

        public Task<int> Complete();
    }
}

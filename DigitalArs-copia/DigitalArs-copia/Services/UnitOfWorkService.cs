using AutoMapper;
using DigitalArs_copia.DataAccess;
using DigitalArs_copia.DataAccess.Repositories;

namespace DigitalArs_copia.Services
{
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _contextDB;

        private readonly IMapper _mapper;
        public UserRepository UserRepository { get; set; }

        public AccountRepository AccountRepository { get; set; }

        public RoleRepository RoleRepository { get; set; }

        AccountRepository IUnitOfWork.AccountRepository => throw new NotImplementedException();

        public UnitOfWorkService(ContextDB contextDB, IMapper mapper)
        {
            _contextDB = contextDB;
            _mapper = mapper;
            UserRepository = new UserRepository(_contextDB, _mapper);
            AccountRepository = new AccountRepository(_contextDB, _mapper);
            RoleRepository = new RoleRepository(_contextDB, _mapper);
        }

        public Task<int> Complete()
        {
            return _contextDB.SaveChangesAsync();
        }
    }
}

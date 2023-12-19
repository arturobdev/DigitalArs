using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;

namespace DigitalArs_copia.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<List<AccountDTO>> GetAllAccounts(int parameter);
        public Task<AccountDTO> GetAccountById(int id);
        public Task<bool> DeleteAccountById(int id, int parameter);
        public Task<bool> UpdateAccount(CreateAccountDTO accountDTO, int id);
        public Task<bool> InsertAccount(CreateAccountDTO accountDTO);
    }
}

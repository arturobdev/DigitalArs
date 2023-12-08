using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;

namespace DigitalArs_copia.DataAccess.Repositories.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<List<AccountDTO>> GetAllAccounts(int parameter);
        public Task<AccountDTO> GetAccountById(int id, int parameter);
        public Task<bool> DeleteAccountById(int id, int parameter);
        public Task<bool> UpdateAccount(AccountDTO accountDTO, int id, int paramater);
        public Task<bool> InsertAccount(AccountDTO accountDTO);
    }
}

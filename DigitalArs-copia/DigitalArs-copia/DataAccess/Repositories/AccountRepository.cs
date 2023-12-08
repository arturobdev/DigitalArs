using AutoMapper;
using DigitalArs_copia.DataAccess.Repositories.Interfaces;
using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalArs_copia.DataAccess.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly IMapper _mapper;

        public AccountRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;

        }

        public async Task<bool> UpdateAccount(AccountDTO accountDTO, int id, int parameter)
        {
            try
            {

                var accountFinding = await GetById(id);

                if (accountFinding == null)
                {
                    return false;
                }
                if (parameter == 0)
                {

                    var account = _mapper.Map<Account>(accountDTO);
                    _mapper.Map(account, accountFinding);
                    _contextDB.Update(accountFinding);
                    return true;

                }
                if (accountFinding.IsBlocked == false && parameter == 1)
                {
                    accountFinding.IsBlocked = true;
                    _contextDB.Update(accountFinding);
                    return true;

                }

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public virtual async Task<List<AccountDTO>> GetAllAccounts(int parameter)
        {
            try
            {
                if (parameter == 0)
                {
                    List<Account> accounts = await _contextDB.Accounts
                        .Include(account => account.User)
                        .Where(account => account.IsBlocked == false)
                        .ToListAsync();

                    return _mapper.Map<List<AccountDTO>>(accounts);
                }
                else if (parameter == 1)
                {
                    List<Account> accounts = await _contextDB.Accounts.Include(account => account.User).ToListAsync();
                    return _mapper.Map<List<AccountDTO>>(accounts);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }


        public async Task<AccountDTO> GetAccountById(int id, int parameter)
        {
            try
            {
                Account account = await _contextDB.Accounts
                            .Include(account => account.User)
                            .Where(u => u.Id == id)
                            .FirstOrDefaultAsync();

                if (account == null)
                {
                    return null;
                }
                return _mapper.Map<AccountDTO>(account);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> DeleteAccountById(int id, int parameter)
        {

            try
            {
                Account accountFinding = await base.GetById(id);

                if (accountFinding == null)
                {
                    return false;
                }

                if (parameter == 0)
                {
                    accountFinding.IsBlocked = true;
                    _contextDB.Update(accountFinding);

                    return true;
                }
                if (parameter == 1)
                {
                    _contextDB.Accounts.Remove(accountFinding);
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public virtual async Task<bool> InsertAccount(AccountDTO accountDTO)
        {
            try
            {
                var account = _mapper.Map<Account>(accountDTO);
                var response = await base.Insert(account);
                return response;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

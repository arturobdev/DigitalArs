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

        public async Task<bool> UpdateAccount(CreateAccountDTO accountDTO, int id)
        {
            try
            {
  

                var accountFinding = await GetById(id);

                if (accountFinding == null)
                {
                    return false;
                }
                
                accountFinding.UserId = (int)accountDTO.UserId;
                
                accountFinding.IsBlocked = (bool)accountDTO.IsBlocked;
               
               accountFinding.Money = (decimal)accountDTO.Money;
                
                
                 _contextDB.Update(accountFinding);
                 return true;

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
                    List<Account> accounts = await _contextDB.Accounts.
                        Include(account => account.User)
                       .Where(account => account.IsBlocked == true)
                        .ToListAsync();
                    return _mapper.Map<List<AccountDTO>>(accounts);
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }

        }


        public async Task<AccountDTO> GetAccountById(int id)
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

        public async Task<AccountDTO> GetAccountByUserId(int id)
        {
            try
            {
                Account account = await _contextDB.Accounts
                            .Where(u => u.UserId == id)
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

        public virtual async Task<bool> InsertAccount(CreateAccountDTO accountDTO)
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

        public async Task<bool> Transfer(int id, TransferDTO transferDTO)
        {
            try
            {
                var sendingAccount = await this.Extract(id, transferDTO.Money);
                var receptorAccount = await this.Deposit(transferDTO.AccountReceptorId, transferDTO.Money);
                if(!sendingAccount || !receptorAccount)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Deposit(int id, decimal money)
        {
            try
            {
                var receptorAccount = await base.GetById(id);
                if(receptorAccount == null || receptorAccount.IsBlocked)
                {
                    return false;
                }
                receptorAccount.Money += money;
                _contextDB.Update(receptorAccount);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Extract(int id, decimal money)
        {
            try
            {
                var existingAccount = await base.GetById(id);
                if (existingAccount == null || existingAccount.IsBlocked || existingAccount.Money < money)
                {
                    return false;
                }
                existingAccount.Money -= money;
                _contextDB.Update(existingAccount);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

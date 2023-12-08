using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;
using DigitalArs_copia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArs_copia.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int parameter = 0)
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAccounts(parameter);
            return Ok("Hola") ;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, int parameter = 0)
        {
            var account = await _unitOfWork.AccountRepository.GetById(id);
            
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> AddAcount(AccountDTO accountDTO)
        {
            
            return Ok(await _unitOfWork.AccountRepository.InsertAccount(accountDTO));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(int id, AccountDTO accountDTO, int parameter = 0)
        {
            var result = await _unitOfWork.AccountRepository.UpdateAccount(accountDTO,id,parameter);
            ;
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id, int parameter = 0)
        {
            var result = await _unitOfWork.AccountRepository.DeleteAccountById(id, parameter);
          
            return Ok(result);
        }
    }
}

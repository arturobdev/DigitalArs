using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;
using DigitalArs_copia.Infraestructure;
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
            try
            {
                var accounts = await _unitOfWork.AccountRepository.GetAllAccounts(parameter);
                return ResponseFactory.CreateSuccessResponse(200, accounts);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened, please try again.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, int parameter = 0)
        {
            try
            {
                var account = await _unitOfWork.AccountRepository.GetById(id);
                return ResponseFactory.CreateSuccessResponse(200, account);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened, please try again.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAcount(AccountDTO accountDTO)
        {
            try
            {
                var response = await _unitOfWork.AccountRepository.InsertAccount(accountDTO);
                if (response == true)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Account was added.");
                }
                return ResponseFactory.CreateErrorResponse(400, "Error adding account, make sure that user exist.");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A suprise error happened.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] int id, AccountDTO accountDTO, int parameter = 0)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.UpdateAccount(accountDTO, id, parameter);
                if (result == true)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Account was successfuly edited.");
                }
                return ResponseFactory.CreateErrorResponse(400, "Error editing account, make the information is correct.");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "Surprise error happened.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] int id, int parameter = 0)
        {
            try
            {
                var result = await _unitOfWork.AccountRepository.DeleteAccountById(id, parameter);
                if (result == true)
                {
                    await _unitOfWork.Complete();
                    return ResponseFactory.CreateSuccessResponse(200, "Succesful removal");
                }
                return ResponseFactory.CreateErrorResponse(400, "Error deleting account.");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "Error deleting account.");
            }
        }
    }
}

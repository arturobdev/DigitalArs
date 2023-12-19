using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Infraestructure;
using DigitalArs_copia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArs_copia.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Policy = "Administrator")]
        public async Task<IActionResult> GetAll(int parameter = 0)
        {

            try
            {
                var usersDTO = await _unitOfWork.UserRepository.GetAllUsers(parameter);
                return ResponseFactory.CreateSuccessResponse(200, usersDTO);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "A surprise error happened");

            }

        }

        [HttpGet("{id}")]
        [Authorize(Policy = "AdministratorAndUser")]
        public async Task<IActionResult> GetById(int id, int parameter = 0)
        {
            try
            {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.UserRepository.GetById(id));
            }
            catch (Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> InsertUser(UserRegisterDTO userRegisterDTO)
        {
            try
            {
            var result = await _unitOfWork.UserRepository.InsertUser(userRegisterDTO);
            if(result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Success");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error");
            }
            catch(Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdministratorAndUser")]
        public async Task<IActionResult> UpdateUser([FromBody]UserRegisterDTO userRegisterDTO, [FromRoute] int id, int parameter = 0)
        {
            try
            {
            var result = await _unitOfWork.UserRepository.UpdateUser(userRegisterDTO, id, parameter);
            if(result)
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Success");
            }
            return ResponseFactory.CreateErrorResponse(400, "Error");
            }
            catch(Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdministratorAndUser")]
        public async Task<IActionResult> DeleteUserById([FromRoute]int id, int parameter = 0)
        {
            try
            {
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.UserRepository.DeleteUserById(id, parameter));
            }
            catch(Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }
    }
}

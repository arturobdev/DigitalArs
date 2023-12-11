using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Infraestructure;
using DigitalArs_copia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalArs_copia.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int parameter = 0)
        {
            try
            {
              return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.RoleRepository.GetAllRoles(parameter));
            }
            catch (Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, int parameter = 0)
        {
            try 
            {
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.RoleRepository.GetById(id));
            }
            catch (Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleDTO roleDTO)
        {
            try
            {
            var result = await _unitOfWork.RoleRepository.InsertRole(roleDTO);
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
        public async Task<IActionResult> UpdateRole(int id, RoleDTO roleDTO, int parameter = 0)
        {
            try 
            {
            var result = await _unitOfWork.RoleRepository.UpdateRole(roleDTO, id, parameter);
            if ((bool)result)
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
        public async Task<IActionResult> DeleteRole(int id, int parameter = 0)
        {
            try
            {
            await _unitOfWork.Complete();
            return ResponseFactory.CreateSuccessResponse(200, await _unitOfWork.RoleRepository.DeleteRoleById(id, parameter));
            }
            catch(Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }
    }
}

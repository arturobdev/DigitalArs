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
                var rolesDTO = await _unitOfWork.RoleRepository.GetAllRoles(parameter);
                return ResponseFactory.CreateSuccessResponse(200, rolesDTO);
            }
            catch (Exception ex) 
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, int parameter = 0)
        {
            var role = await _unitOfWork.RoleRepository.GetById(id);
            return ResponseFactory.CreateSuccessResponse(200, role);
        }
    }
}

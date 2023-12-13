using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Services;
using DigitalArs_copia.Helper;
using DigitalArs_copia.Infraestructure;
using Microsoft.AspNetCore.Authorization;

namespace DigitalArs_copia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TokenJwtHelper _tokenJwtHelper;

        public AuthController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }


        [HttpPost]

        public async Task<IActionResult> Login(AuthenticateDTO authenticateDTO)
        {
            try
            {
                var usersCredentials = await _unitOfWork.UserRepository.AuthenticateCredentials(authenticateDTO);
                if (usersCredentials is null)
                {
                    return ResponseFactory.CreateErrorResponse(401, "The credentials are incorrect");
                }

                var token = _tokenJwtHelper.GenerateToken(usersCredentials);

                return ResponseFactory.CreateSuccessResponse(200, token);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error hapenned");
            }
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetMyProfile()
        {
            try
            {
                var userId = User.FindFirst("userId")?.Value;
                var user = await _unitOfWork.UserRepository.GetUserById(int.Parse(userId), 0);
                return ResponseFactory.CreateSuccessResponse(200, user);
            }
            catch {
                return ResponseFactory.CreateErrorResponse(500, "Unexpected error hapenned");
            
            }
        }
    }
}

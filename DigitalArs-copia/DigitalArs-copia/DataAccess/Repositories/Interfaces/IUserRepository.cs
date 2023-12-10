using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;

namespace DigitalArs_copia.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<List<User>> GetAllUsers(int parameter);
        public Task<User> GetUserById(int id, int parameter);
        public Task<bool> DeleteUserById(int id, int parameter);
        public Task<bool> UpdateUser(UserRegisterDTO userRegisterDTO, int id, int parameter);
        public Task<bool> InsertUser(UserRegisterDTO userRegisterDTO);
        public Task<User?> AuthenticateCredentials(AuthenticateDTO dto);
    }
}

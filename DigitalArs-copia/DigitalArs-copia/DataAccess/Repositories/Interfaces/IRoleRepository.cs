using DigitalArs_copia.Entities;

namespace DigitalArs_copia.DataAccess.Repositories.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        public Task<List<Role>> GetAllRoles(int parameter);
        public Task<Role> GetRoleById(int id, int parameter);
        public Task<bool> DeleteRoleById(int id, int parameter);
        //public Task<bool> UpdateRole(RoleDTO roleDTO, int id, int paramater);
    }
}

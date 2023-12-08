using AutoMapper;
using DigitalArs_copia.DataAccess.Repositories.Interfaces;
using DigitalArs_copia.DTO_s;
using DigitalArs_copia.Entities;
using System.Data;

namespace DigitalArs_copia.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IMapper _mapper;

        public RoleRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;
        }

        public virtual async Task<List<Role>> GetAllRoles(int parameter)
        {
            try
            {
                var roles = await base.GetAll();
                if (parameter == 0)
                {
                    roles = roles.ToList();
                    return roles;

                }
                else if (parameter == 1)
                {
                    return roles;

                }
                return null;

            }
            catch (Exception)
            {
                return null;

            }
        }

        public async Task<Role> GetRoleById(int id, int parameter)
        {
            try
            {
                Role roleFinding = await base.GetById(id);
                if (roleFinding == null)
                {
                    return null;
                }
                if ( parameter == 0)
                {
                    return roleFinding;
                }
                if (parameter == 1)
                {
                    return roleFinding;
                }
                return null;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual async Task<bool> InsertRole(RoleDTO roleDTO)
        {
            try
            {
                var role = _mapper.Map<Role>(roleDTO);
                var response = await base.Insert(role);
                return response;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateRole(RoleDTO roleDTO, int id, int parameter)
        {
            try
            {
                var role = _mapper.Map<Role>(roleDTO);
                var roleFinding = await GetById(id);
                if (roleFinding == null)
                {
                    return false;
                }
                if (parameter == 0)
                {
                    _mapper.Map(role, roleFinding);
                    await _contextDB.SaveChangesAsync();
                    return true;
                }
                if (parameter == 1)
                {
                    _mapper.Map(role, roleFinding);
                    await _contextDB.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteRoleById(int id, int parameter)
        {

            try
            {
                Role roleFinding = await GetById(id);
                if (roleFinding == null)
                {
                    return false;
                }

                if (roleFinding != null)
                {
                    _contextDB.Roles.Remove(roleFinding);
                    await _contextDB.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

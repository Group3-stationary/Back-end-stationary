using StationaryServer2.Models.Stationary;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        public Task<Permission> Create(Permission permission)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.IEnumerable<Permission>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Permission> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Permission permission)
        {
            throw new System.NotImplementedException();
        }
    }
}

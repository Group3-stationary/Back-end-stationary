using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> Get();
        Task<Permission> Get(int id);
        Task<Permission> Create(Permission permission);
        Task Update(Permission permission);
        Task Delete(int id);
    }
}

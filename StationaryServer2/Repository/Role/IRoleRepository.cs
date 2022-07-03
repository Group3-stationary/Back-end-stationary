using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> Get();
        Task<Role> Get(int id);
        Task<Role> Create(Role role);
        Task Update(Role role);
        Task Delete(int id);
    }
}

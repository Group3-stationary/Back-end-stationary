using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string id);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(string id);
    }
}

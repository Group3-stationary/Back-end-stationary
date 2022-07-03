using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<Employee> Create(Employee employee)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}

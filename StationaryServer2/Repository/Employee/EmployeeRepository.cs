using Microsoft.EntityFrameworkCore;
using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StationeryContext db;
        public EmployeeRepository(StationeryContext db)
        {
            this.db = db;
        }
        public async Task<Employee> Create(Employee employee)
        {
            db.Employees.Add(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task Delete(string id)
        {
            var data = await db.Employees.FindAsync(id);
            if (data != null)
            {
                db.Employees.Remove(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var data = await db.Employees.ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(string id)
        {
            var data = await db.Employees.FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}

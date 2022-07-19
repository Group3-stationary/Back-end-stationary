using StationaryServer2.Models.Stationary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class RepositoryAll : IRepositoryAll
    {
        public readonly StationeryContext _db;
        public RepositoryAll(StationeryContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteRoleEmpid(string empid)
        {
            var dataRole = _db.EmployeeRoles.SingleOrDefault(e => e.EmployeeId.Equals(empid));
            var dataRefresh = _db.RefreshTokens.Where(e => e.EmployeeId.Equals(empid));
            if (dataRole != null)
            {
                _db.EmployeeRoles.Remove(dataRole);
                _db.SaveChanges();
            }
            if (dataRefresh != null)
            {
                _db.RefreshTokens.RemoveRange(dataRefresh);
                _db.SaveChanges();
            }
            return true;
        }
    }
}

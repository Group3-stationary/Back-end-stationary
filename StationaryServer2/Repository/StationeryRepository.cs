using Microsoft.EntityFrameworkCore;
using StationaryServer2.Models.Stationary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class StationeryRepository<T>:IStationeryRepository<T> where T : class
    {
        public readonly StationeryContext _db;
        public StationeryRepository(StationeryContext db)
        {
            _db = db;
        }

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> GetById<TId>(TId id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
        }

        public Task<List<T>> ListAll()
        {
            return _db.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}

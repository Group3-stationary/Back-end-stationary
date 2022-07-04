using StationaryServer2.Models.Stationary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface IStationeryRepository<T> where T : class
    {
        Task<T> GetById<TId>(TId id);
        Task<List<T>> ListAll();
        Task Insert(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        //Task<List<T>> ListAsyncSpec(ISpecification<T> spec);
        //Task<T> GetAsyncSpec(ISpecification<T> spec);
    }
}

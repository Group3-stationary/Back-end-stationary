using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task<Product> Create(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}

using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> Create(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Product>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}

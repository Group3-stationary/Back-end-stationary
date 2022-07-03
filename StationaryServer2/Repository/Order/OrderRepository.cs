using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order> Create(Order order)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Order>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}

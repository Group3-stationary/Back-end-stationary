using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> Create(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}

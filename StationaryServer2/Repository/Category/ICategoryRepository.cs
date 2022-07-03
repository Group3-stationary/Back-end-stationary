using StationaryServer2.Models.Stationary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StationaryServer2.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationaryServer2.Models.Stationary;

namespace StationaryServer2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StationeryContext db;
        public CategoryRepository(StationeryContext db)
        {
            this.db = db;
        }

        public Task<Category> Create(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await db.Categories.FindAsync(id);
        }

        public async Task Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}

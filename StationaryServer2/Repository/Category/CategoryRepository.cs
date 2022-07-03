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


        public async Task<Category> CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return category;

        }

        public async Task DeleteCategory(int id)
        {
            var data = await db.Categories.FindAsync(id);
            if (data != null)
            {
                db.Categories.Remove(data);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var data = await db.Categories.ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Category> GetCategory(int id)
        {
            var data = await db.Categories.SingleOrDefaultAsync(e=>e.CategotyId.Equals(id));
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task UpdateCategory(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}

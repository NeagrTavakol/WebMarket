using Microsoft.EntityFrameworkCore;
using WebMarket.DataAccess;
using WebMarket.DataAccesss.Repository.IRepository;
using WebMarket.Models;

namespace WebMarket.DataAccesss.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
        /*public void Save()
        {
            _db.SaveChanges();
        }*/

        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}

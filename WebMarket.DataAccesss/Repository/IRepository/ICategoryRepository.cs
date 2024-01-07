using WebMarket.Models;

namespace WebMarket.DataAccesss.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}

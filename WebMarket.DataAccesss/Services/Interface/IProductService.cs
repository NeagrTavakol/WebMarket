using System.Linq.Expressions;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.DataAccesss.Services.Interface
{
    public interface IProductService
    {
        public void Add(ProductVM entity);
        public IEnumerable<Product> GetAll();
        public void Remove(Product entity);
        public void RemoveRange(IEnumerable<Product> entities);
        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter);
        public void Save();
        public void Update(ProductVM obj);
    }
}

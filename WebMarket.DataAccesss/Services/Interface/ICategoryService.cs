using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccesss.Services.Interface
{
    public interface ICategoryService
    {
        public void Add(Category entity);
        public IEnumerable<Category> GetAll();
        public void Remove(Category entity);
        public void RemoveRange(IEnumerable<Category> entities);
        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter);
        public void Save();
        public void Update(Category obj);
    }
}

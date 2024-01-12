using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.DataAccess;
using WebMarket.DataAccess.Migrations;
using WebMarket.DataAccesss.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccesss.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Category entity)
        {
            _db.categories.Add(entity);
        }

        public IEnumerable<Category> GetAll()
        {
            IQueryable<Category> query = _db.categories;
            return query;
        }

        public void Remove(Category entity)
        {
            _db.categories.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Category> entities)
        {
            _db.categories.RemoveRange(entities);
        }

        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> query = _db.categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}

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
    public class CoverTypeService:ICoverTypeService
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(CoverType entity)
        {
            _db.coverTypes.Add(entity);
        }

        public IEnumerable<CoverType> GetAll()
        {
            IQueryable<CoverType> query = _db.coverTypes;
            return query;
        }

        public void Remove(CoverType entity)
        {
            _db.coverTypes.Remove(entity);
        }

        public void RemoveRange(IEnumerable<CoverType> entities)
        {
            _db.coverTypes.RemoveRange(entities);
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter)
        {
            IQueryable<CoverType> query = _db.coverTypes;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CoverType obj)
        {
            _db.coverTypes.Update(obj);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMarket.DataAccess;
using WebMarket.DataAccesss.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.DataAccesss.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(ProductVM entity)
        {
            _db.Products.Add(entity.Product);
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products.Include(c => c.Category).Include(c => c.CoverType);
            return query;
        }

        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            _db.SaveChanges();
        }

        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            var ObjProduct = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if(ObjProduct != null)
            {
                ObjProduct.Title = obj.Title;
                ObjProduct.Description = obj.Description;
                ObjProduct.ShortDescription = obj.ShortDescription;
                ObjProduct.Price = obj.Price;
                ObjProduct.ListPrice = obj.ListPrice;
                ObjProduct.Price100=obj.Price100;
                ObjProduct.Price50=obj.Price50;
                ObjProduct.ISBN= obj.ISBN;
                ObjProduct.Author= obj.Author;
                ObjProduct.CategoryId= obj.CategoryId;
                ObjProduct.CoverTypeId= obj.CoverTypeId;
                if(obj.ImgeUrl!=null)
                {
                    ObjProduct.ImgeUrl = obj.ImgeUrl;
                }
                
                ObjProduct.ImageAlt = obj.ImageAlt;
                ObjProduct.ImageTitle= obj.ImageTitle;
            }
            _db.SaveChanges();
        }
    }
}

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
            IQueryable<Product> query = _db.Products;
            return query;
        }

        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
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

        public void Update(ProductVM obj)
        {
            var ObjProduct = _db.Products.FirstOrDefault(x => x.Id == obj.Product.Id);
            if(ObjProduct != null)
            {
                ObjProduct.Title = obj.Product.Title;
                ObjProduct.Description = obj.Product.Description;
                ObjProduct.ShortDescription = obj.Product.ShortDescription;
                ObjProduct.Price = obj.Product.Price;
                ObjProduct.ListPrice = obj.Product.ListPrice;
                ObjProduct.Price100=obj.Product.Price100;
                ObjProduct.Price50=obj.Product.Price50;
                ObjProduct.ISBN= obj.Product.ISBN;
                ObjProduct.Author= obj.Product.Author;
                ObjProduct.CategoryId= obj.Product.CategoryId;
                ObjProduct.CoverTypeId= obj.Product.CoverTypeId;
                ObjProduct.ImgeUrl= obj.Product.ImgeUrl;
                ObjProduct.ImageAlt = obj.Product.ImageAlt;
                ObjProduct.ImageTitle= obj.Product.ImageTitle;
            }
        }
    }
}

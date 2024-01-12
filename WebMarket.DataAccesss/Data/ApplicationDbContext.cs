using Microsoft.EntityFrameworkCore;
using WebMarket.Models;



namespace WebMarket.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<CoverType> coverTypes { get; set; }
    }
}

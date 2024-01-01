using Microsoft.EntityFrameworkCore;
using WebMarket.web.Models;

namespace WebMarket.web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> categories { get; set; }
    }
}

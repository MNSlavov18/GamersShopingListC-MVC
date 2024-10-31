using GamersShopingListC_MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamersShopingListC_MVC.Data
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Game> Games { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }

        
    }
}

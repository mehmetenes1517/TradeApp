using Microsoft.EntityFrameworkCore;
using TradeApp.Models;

namespace TradeApp.Data.Main{
    public class TradeContext:DbContext{
        public DbSet<User> Users=>Set<User>();
        public DbSet<Product> Products=>Set<Product>();
        public TradeContext(DbContextOptions<TradeContext> options):base(options)
        {
            
        }
    }
}
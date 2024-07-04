using TradeApp.Data.Abstract;
using TradeApp.Models;

namespace TradeApp.Data.Main{
    public class UserContext : IUserContext
    {
        public TradeContext _context;
        public UserContext(TradeContext context){
            _context=context;
        }
        public IQueryable<User> user_list => _context.Users;

        public IQueryable<Product> product_list => _context.Products;

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
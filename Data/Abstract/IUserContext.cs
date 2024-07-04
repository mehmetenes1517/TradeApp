using TradeApp.Models;

namespace TradeApp.Data.Abstract{
    public interface IUserContext{
        public IQueryable<User> user_list{get;}
        public IQueryable<Product> product_list{get;}
        public void CreateUser(User user);
        public void CreateProduct(Product product);
    }
}
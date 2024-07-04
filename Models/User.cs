using System.ComponentModel.DataAnnotations;

namespace TradeApp.Models{

    public class User{
        [Key]
        public int? UserId{set;get;}
        public string? name{set;get;}
        public string? username{set;get;}
        public string? password{set;get;}
        public List<Product> product=null!;
    }

}
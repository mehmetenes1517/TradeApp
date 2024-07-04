using System.ComponentModel.DataAnnotations;

namespace TradeApp.Models{
    public class Product{
        [Key]
        public int ProductId{set;get;}
        public string? ProductName{set;get;}
        public string? ProductImage{set;get;}
        public int? ProductPrice{set;get;}
        public int? OwnerId{set;get;}
    }
}
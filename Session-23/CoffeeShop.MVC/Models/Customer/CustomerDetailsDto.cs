using CoffeeShop.Model;

namespace CoffeeShop.MVC.Models.Customer {
    public class CustomerDetailsDto {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public List<Transaction> Transactions { get; set; }=new List<Transaction>();
    }
}

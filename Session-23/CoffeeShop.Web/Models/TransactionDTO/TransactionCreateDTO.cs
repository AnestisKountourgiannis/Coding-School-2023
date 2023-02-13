﻿using CoffeeShop.Model;
using CoffeeShop.Model.Enums;

namespace CoffeeShop.Web.Models.TransactionDTO
{
    public class TransactionCreateDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; } 

        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; } 

        public List<TransactionLine>? TransactionLines { get; set; }
    }
}

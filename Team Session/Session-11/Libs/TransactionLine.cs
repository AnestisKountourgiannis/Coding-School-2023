using Session_11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Libs
{
    public class TransactionLine
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        public Transaction Transaction { get; set; }
        public Product Product { get; set; }

        public TransactionLine ()
        { 
            ID= Guid.NewGuid ();
        }
        
        public TransactionLine(Guid productID, int quantity, double price, double discount)
        {
            ProductID = productID;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }

        //Method that calculates the Price : Example : 3 x Fredo Espress (2euros) = 6euros
        public void CalculatePriceLine() {
            TotalPrice = Quantity * Price;  
        }

        //Helping ones may be used later 
        

    }
}






    
   


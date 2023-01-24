using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///Summary
///TransactionHandler will be the instance we call that does all the basic processes
///here will do produc calculations , discount 
///remove or add discoun , check payment method 
///update and possuibly export a json
///Later in the implementation it will have a role of housekeeping ledger 
///

namespace Libs {
    internal class TransactionHandler {

        private double _discountPercent = 0.15;
        private double _discountThreshold = 10;
        public Transaction Trans { get; set; } = new(); 
        public TransactionLine  transLine { get; set; } = new();

        public TransactionHandler() { } 


        //add trans.lines to transaction
        public void AddLineToTrans(TransactionLine trLine) {
            Trans.TransactionLines.Add(trLine);

        }

        //calculates total cost and adds it to Transaction.TotalPrice
       public void CalculateTotalCost() {
            double totalCost= 0;
            foreach(var tr in Trans.TransactionLines) {
                 tr.CalculatePriceLine();
                totalCost += tr.TotalPrice;
            }
            Trans.TotalPrice = CalculateDiscountPrice(totalCost);    
        }

        //checks and calculates discount if possbile
        public double CalculateDiscountPrice(double cost) {
            if (cost > _discountThreshold) {
                cost = cost - (cost * _discountPercent);
            }
            return cost;
        }
        //checks for payment method availability
        public bool PaymentWithCard(double price) {
            if (price >= 50) {
                return false;
            }
            else { return true; }
        }



    }    
}

/*
 * Business : 
 * initially on the farm we want the menu to display things to add to the cart. Each time u pick an option eg.(espresso) and quantiny x3.
 * After Accept the form creates and sends the coresponding 
*/
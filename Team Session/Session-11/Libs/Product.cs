using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_11
{
    public class Product
    {
        public Guid ProductID { get; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Guid ProductCategoryID { get; }
        public double Price { get; set; }
        public double Cost { get; set; }


        public Product()
        {
            ProductID = Guid.NewGuid();
        }
        

    }
}



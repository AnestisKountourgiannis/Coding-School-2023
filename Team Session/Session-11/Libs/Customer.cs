using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs {

    public class Customer {

        public Guid ID { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }


        //TODO:add customer info so it agrees with Buseiness Rules
        public Customer() {
            ID = Guid.NewGuid();
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Institute
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public int YearsInService { get; set; }
        public Institute()
        {
            ID = Guid.NewGuid();
        }

        public Institute(string name, int yearsInService)
        {
            ID = Guid.NewGuid();
            Name = name;
            YearsInService = yearsInService;
        }
        public void GetName()
        {
        
        }
        public void SetName(string name)
        {
          
        }
    }
}
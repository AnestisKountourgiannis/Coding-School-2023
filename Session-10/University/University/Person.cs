using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    public class Person
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {
            ID = Guid.NewGuid();
        }
        public Person(string name, int age)
        {
            ID = Guid.NewGuid();
            Name = name;
            Age = age;
        }
        public void GetName()
        {

        }
        public void SetName(string name)
        {
            
        }
    }
}
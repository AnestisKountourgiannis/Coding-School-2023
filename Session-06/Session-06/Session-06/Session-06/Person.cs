using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class Person
    {

        // properties
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        // constructors
        public Person()
        {

        }

        public Person(Guid id)
        {
            Guid ID = id;
        }

        public Person(Guid id, string name)
        {
           Guid  ID = id;
            string Name = name;
        }

        public Person(Guid id, string name, int age)
        {
            Guid ID = id;
           string Name = name;
           int Age = age;
        }

        // methods
        public void GetName()
        {

        }

        public void SetName(string name)
        {


        }

    }
}
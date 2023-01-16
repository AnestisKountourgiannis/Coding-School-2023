using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    //properties
    public class Person
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    //constructors
    public Person() {
    }
    public Person(Guid id) {
        ID = id;
    }
    public Person(Guid id, string name) {
        ID = id;
        Name = name;
    } 
    public Person(Guid id,string name,int age)
    {
        ID = id;
        Name = name;
        Age = age;
    }
//methods
public void GetName() {
    }
public void SetName(string name) {
    }
}

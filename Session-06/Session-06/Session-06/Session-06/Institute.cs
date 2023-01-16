using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public class Institute
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public int YearsInService { get; set; }
    }
    //constructors
    public Institute()
    {

    }
    public Institute(Guid id)
    {
        ID = id;
    }
    public Institute(Guid id, string name)
    {
        ID = id;
        Name = name;
    }
    public Institute(Guid id, string name, int age)
    {
        ID = id;
        Name = name;
        YearsInService = age;
    }
    //Methods
    public void GetName()
    {

    }
    public void SetName(string name)
    {

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_06
{
    public partial class Professor : Component
    {
        public Professor()
        {
            InitializeComponent();
        }

        public Professor(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}

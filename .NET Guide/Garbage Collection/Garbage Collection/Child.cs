using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garbage_Collection
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }

        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            //GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garbage_Collection
{
    public partial class Parent : Form
    {
        Example example = null;
        public Parent()
        {
            InitializeComponent();
            lblUsedMemory.Text = GetProcessUsedMemory();
            example = new Example();
            example.A = "A";
            example.B = "B";
        }

        public string GetProcessUsedMemory()
        {

            double usedMemory = 0;

            usedMemory = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;

            return $"{usedMemory} MB";
        }

        private void btnRefreshUsedMemory_Click(object sender, EventArgs e)
        {
            lblUsedMemory.Text = GetProcessUsedMemory();
        }

        private void btnOpenChild_Click(object sender, EventArgs e)
        {
            Child child = new Child();
            child.Show();
            //child.Dispose();
        }

        private void btnFlushMemory_Click(object sender, EventArgs e)
        {
            MessageBox.Show(example.A);
            MemoryManagement.FlushMemory();
            Thread.Sleep(3000);
            MessageBox.Show(example.A);
        }
    }

    class Example
    {
        public string A { get; set; }
        public string B { get; set; }
    }
}

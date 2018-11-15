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

        private void Child_Load(object sender, EventArgs e)
        {
            AddButton();
            pictureBox1.Image = Properties.Resources.sam_trotman_758969_unsplash;
        }

        private void AddButton()
        {
            // Create a button and add it to the form.
            Button button1 = new Button();

            // Anchor the button to the bottom right corner of the form.
            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);

            // Assign a background image.
            button1.BackgroundImage = Image.FromFile($"{AppDomain.CurrentDomain.BaseDirectory}images//sam-trotman-758969-unsplash.jpg");

            // Specify the layout style of the background image.Title is the default.
            button1.BackgroundImageLayout = ImageLayout.Stretch;

            // Specify the size of the button.
            button1.Size = new Size(200, 100);

            // Set the button's TabIndex and TabStop properties.
            button1.TabIndex = 1;
            button1.TabStop = true;

            // Add a delegate to handle the Click event.
            button1.Click += new EventHandler((object sender, EventArgs e) =>
            {
                MessageBox.Show("Hi.");
            });

            // Add the button to the form.
            this.Controls.Add(button1);
        }

        private void Child_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            foreach (var control in this.Controls)
            {
                if (control.GetType().Name == nameof(Button))
                {
                    var btn = (Button)control;
                    if (btn.BackgroundImage != null)
                    {
                        btn.BackgroundImage.Dispose();
                        btn.BackgroundImage = null;
                    }
                }
            }
        }
    }
}

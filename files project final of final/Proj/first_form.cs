using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proj
{
    public partial class first_form : Form
    {
        public first_form()
        {
            InitializeComponent();
            userControl11.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            UserControl1 usercontrol = new UserControl1();
            userControl11.Visible = true;
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }
    }
}

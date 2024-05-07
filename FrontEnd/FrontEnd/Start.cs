using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
    public partial class Start : Form
    {
        public static Start Instance;
        public Start()
        {
            InitializeComponent();
            Instance = this;    
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form form = new Form1();
            form.Show();

        }
    }
}

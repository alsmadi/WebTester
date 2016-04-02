using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebTester
{
    public partial class DlgForm : Form
    {
        public string URL = null;
        public DlgForm()
        {
            InitializeComponent();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            URL= textBox1.Text;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GW2AccountViewer
{
    public partial class Form1 : Form
    {

        private GW2AccounViewerApplication application;

        public Form1()
        {
            InitializeComponent();

            application = new GW2AccounViewerApplication();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            application.saveApiKey(textBox1.Text);
            AccountView accountView = new AccountView();
            accountView.Show();
            this.Hide();
        }
    }
}

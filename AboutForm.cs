using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.TopLevel = true;
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.discordlink);
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

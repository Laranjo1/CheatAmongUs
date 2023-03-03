using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Covid
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            this.TopLevel = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.discordlink);
            Process.Start(Properties.Settings.Default.updatelink);
            Environment.Exit(0);
            Application.Exit();
        }
    }
}

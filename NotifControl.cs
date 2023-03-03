using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace Covid
{
    public partial class NotifControl : UserControl
    {
        public NotifControl()
        {
            InitializeComponent();
            if (!Injection.IsBusy)
            {
                Injection.RunWorkerAsync();
            }
        }
        public Mem m = new Mem();
        public int pID;
        public bool openProcess;
        public bool controleSpeed;
        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Settings.Default.discordlink);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Value + 5;
            }
            else
            {
                pictureBox2.Visible = false;
                bunifuCustomLabel5.Visible = false;
                bunifuCustomLabel2.Visible = true;
                bunifuCustomLabel3.Visible = true;
                bunifuCustomLabel4.Visible = true;
                bunifuImageButton5.Visible = true;
                timer1.Stop();
                progressBar1.Value = progressBar1.Minimum;
            }
        }
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Injection_DoWork(object sender, DoWorkEventArgs e)
        {
            bool open = true;
            while (open)
            {
                Thread.Sleep(100);
                pID = m.GetProcIdFromName("Among Us");
                openProcess = false;
                if (pID > 0 && open == true)
                {
                    Invoke((MethodInvoker)delegate {
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = true;
                        pictureBox2.Image = Covid.Properties.Resources.check;
                        bunifuCustomLabel1.Visible = false;
                        bunifuCustomLabel5.Visible = true;
                        timer2.Start();
                        timer1.Start();
                        Injection.WorkerSupportsCancellation = true;
                        Injection.CancelAsync();
                    });
                    openProcess = m.OpenProcess(pID);
                    Thread.Sleep(100);
                    break;
                }
                Thread.Sleep(100);
                pID = m.GetProcIdFromName("among us");
                openProcess = false;
                if (pID > 0 && open == true)
                {
                    Invoke((MethodInvoker)delegate {
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = true;
                        pictureBox2.Image = Covid.Properties.Resources.check;
                        bunifuCustomLabel1.Visible = false;
                        bunifuCustomLabel5.Visible = true;
                        timer2.Start();
                        timer1.Start();
                        Injection.WorkerSupportsCancellation = true;
                        Injection.CancelAsync();
                    });
                    openProcess = m.OpenProcess(pID);
                    Thread.Sleep(100);
                    break;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((Process.GetProcessesByName("Among Us").Count() < 1 )|| (Process.GetProcessesByName("among us").Count() < 1))
            {
                this.Visible = true;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox2.Image = null;
                bunifuImageButton5.Visible = false;
                bunifuCustomLabel1.Visible = true;
                bunifuCustomLabel2.Visible = false;
                bunifuCustomLabel3.Visible = false;
                bunifuCustomLabel4.Visible = false;
                bunifuCustomLabel5.Visible = false;
                timer2.Stop();
                if (!Injection.IsBusy)
                {
                    Injection.RunWorkerAsync();
                }
            }
        }

        private void NotifControl_Load(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace Covid
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            try
            {
                string[] strArray = this.uwc.DownloadString("https://raw.githubusercontent.com/Seila123457/COVID19/main/Updater.txt").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                MessageBox.Show(strArray[0]);
                string[] lArray = this.lwc.DownloadString("https://raw.githubusercontent.com/Seila123457/COVID19/main/Language.txt").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                Properties.Settings.Default.updatelink = strArray[1];
                Properties.Settings.Default.discordlink = strArray[2];
                if (CultureInfo.InstalledUICulture.Name == "pt-PT")
                {
                    helplink = lArray[1];
                }
                else if (CultureInfo.InstalledUICulture.Name == "pt-BR")
                {
                    helplink = lArray[1];
                }
                else if (CultureInfo.InstalledUICulture.Name == "en-US")
                {
                    helplink = lArray[3];
                }
                else if (CultureInfo.InstalledUICulture.Name == "ko-KR")
                {
                    helplink = lArray[5];
                }
                else if (CultureInfo.InstalledUICulture.Name == "nl-NL")
                {
                    helplink = lArray[7];
                }
                else if (CultureInfo.InstalledUICulture.Name == "fr-FR")
                {
                    helplink = lArray[9];
                }
                else if (CultureInfo.InstalledUICulture.Name == "ru-RU")
                {
                    helplink = lArray[11];
                }
                else if (CultureInfo.InstalledUICulture.Name == "tr-TR")
                {
                    helplink = lArray[13];
                }
                else if (CultureInfo.InstalledUICulture.Name == "es-ES")
                {
                    helplink = lArray[15];
                }
                else if (CultureInfo.InstalledUICulture.Name == "ar-AR")
                {
                    helplink = lArray[17];
                }
                else
                {
                    helplink = lArray[3];
                }

                if (strArray[0] != Application.ProductVersion)
                {
                    this.TopMost = false;
                    this.Hide();
                    new Updater().ShowDialog();
                }

            }
            catch { //Environment.Exit(0); 
            }
            InitializeComponent();
            if (!Injection.IsBusy)
            {
                Injection.RunWorkerAsync();
            }
        }
        public Mem m = new Mem();
        public int pID;
        public bool openProcess;
        public bool aberto = false;
        public long SingleAoBScanResult;
        public long SingleAoBScanResult2;
        public bool abre = false;
        public bool abre2 = false;

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.ImageActive = null;
            bunifuImageButton2.ImageActive = Covid.Properties.Resources.vision;
            bunifuImageButton3.ImageActive = Covid.Properties.Resources.miscellaneous;
            bunifuImageButton1.Image = Covid.Properties.Resources.impostor;
            bunifuImageButton2.Image = Covid.Properties.Resources.eye_32px;
            bunifuImageButton3.Image = Covid.Properties.Resources.automation_32px;
            bunifuImageButton1.Enabled = false;
            bunifuImageButton2.Enabled = true;
            bunifuImageButton3.Enabled = true;
            panel3.Location = new Point(3, bunifuImageButton1.Location.Y - 4);
            tabControl1.SelectTab(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.ImageActive = Covid.Properties.Resources.impostor;
            bunifuImageButton2.ImageActive = null;
            bunifuImageButton3.ImageActive = Covid.Properties.Resources.miscellaneous;
            bunifuImageButton1.Image = Covid.Properties.Resources.knife_32px;
            bunifuImageButton2.Image = Covid.Properties.Resources.vision;
            bunifuImageButton3.Image = Covid.Properties.Resources.automation_32px;
            bunifuImageButton1.Enabled = true;
            bunifuImageButton2.Enabled = false;
            bunifuImageButton3.Enabled = true;
            panel3.Location = new Point(3, bunifuImageButton2.Location.Y - 4);
            tabControl1.SelectTab(1);
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            bunifuImageButton1.ImageActive = Covid.Properties.Resources.impostor;
            bunifuImageButton2.ImageActive = Covid.Properties.Resources.vision;
            bunifuImageButton3.ImageActive = null;
            bunifuImageButton1.Image = Covid.Properties.Resources.knife_32px;
            bunifuImageButton2.Image = Covid.Properties.Resources.eye_32px;
            bunifuImageButton3.Image = Covid.Properties.Resources.miscellaneous;
            bunifuImageButton1.Enabled = true;
            bunifuImageButton2.Enabled = true;
            bunifuImageButton3.Enabled = false;
            panel3.Location = new Point(3, bunifuImageButton3.Location.Y - 4);
            tabControl1.SelectTab(2);
        }
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(helplink);

        }

        private void cForm_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.00)
            {
                this.Opacity -= 0.1;
            }
            else
            {
                cForm.Stop();
                Environment.Exit(0);
            }
        }

        private void oForm_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1.00)
            {
                this.Opacity += 0.1;
            }
            else
            {
                oForm.Stop();
            }
        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            bunifuCustomLabel26.Text = speedSlider.Value.ToString();
            m.FreezeValue(speed, "float", speedSlider.Value.ToString());
        }

        private void bunifuImageButton7_Click_1(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void bunifuImageButton6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            cForm.Start();
        }

        private void impostor_Click(object sender, EventArgs e)
        {

        }

        private void Injection_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                pID = m.GetProcIdFromName("Among Us");
                openProcess = false;
                if (pID > 0 && aberto == false)
                {
                    Thread.Sleep(500);
                    openProcess = m.OpenProcess(pID);
                    aberto = true;

                }
                else
                {
                    pID = m.GetProcIdFromName("among us");
                    if (pID > 0 && aberto == false)
                    {
                        Thread.Sleep(500);
                        openProcess = m.OpenProcess(pID);
                        aberto = true;
                    }
                    else if (pID <= 0 && aberto == true)
                    {
                        aberto = false;
                    }
                }
                Thread.Sleep(1000);
            }
        }
        //temporarias
        public int temp;
        public int temp2;
        public bool used;
        public bool used2;
        //pointers
        public string impostorOf = "GameAssembly.dll+01472280,24,5C,20,34,28";//bruh
        public string lagSwitch = "GameAssembly.dll+013D8568,54,F34";//bruh
        public string kickAll = "GameAssembly.dll+01468840,5C,0,8,18,44";//bruh
        public string host = "GameAssembly.dll+01468840,5C,0,8,18,48";//bruh
        public string superVision = "UnityPlayer.dll+0126A040,C,14,44,4C,1D88";//bruh
        public string speed = "GameAssembly.dll+013F0D24,C8,10,44,4,14";//bruh
        //functions
        public string taskImpostor = "GameAssembly.dll+DC2410";//bruh
        public string killCooldown = "GameAssembly.dll+77429F";//bruha
        public string infRange = "GameAssembly.dll+76D4DB";//bruh
        public string infRange2 = "GameAssembly.dll+76B08B";//bruh
        public string infRange3 = "GameAssembly.dll+39F7E5";//bruh não precisa
        public string ignoreWall = "GameAssembly.dll+76B28A";//bruh to aq 
        public string killImpostor = "GameAssembly.dll+76D5AF";//bruh aq
        public string unlockItens = "GameAssembly.dll+E25BEF";//bruh bah
        public string unlockItens2 = "GameAssembly.dll+E26A5F";//bruh bah
        public string seeGhostChat = "GameAssembly.dll+903466";//bruh POR FAZER
        public string specListGhost = "GameAssembly.dll+767D9F";//bruh
        public string seeImpostor = "GameAssembly.dll+88BD84";//bruh
        public string seeImpostorShh = "GameAssembly.dll+88BFCD";//bruh
        public string antiBan = "GameAssembly.dll+AFBCB0";//bruh
        public string fastChat = "GameAssembly.dll+90F213";//bruh     
        public string doorCooldown = "GameAssembly.dll+F0E1D4";//bruh
        public string doorCooldown2 = "GameAssembly.dll+72604C";//bruh
        public string wallHack = "UnityPlayer.dll+960CA5";//bruh
        public string sabInf1 = "GameAssembly.dll+CCBDF1";//bruh
        public string sabInf2 = "GameAssembly.dll+CCBE27";//bruh
        public string sabInf3 = "GameAssembly.dll+CCBE61";//bruh
        public string sabInf4 = "GameAssembly.dll+CCBE97";//bruh
        public string sabInf5 = "GameAssembly.dll+CCBF01";//bruh
        public string canUse = "GameAssembly.dll+8AC7E0";//bruh
        public string unBan = "GameAssembly.dll+88C626";//bruh
        public string FixedUpdate = "GameAssembly.dll+887E00";//bruh
        public string SkipAll = "GameAssembly.dll+8E878A";//bruh
        public string SkipAll2 = "GameAssembly.dll+8E05F9";//bruh
        public string SkipAll3 = "GameAssembly.dll+8E878F";//bruh
        private void chkImpostor_OnChange(object sender, EventArgs e)
        {
            if (chkImpostor.Checked)
            {
                m.FreezeValue(impostorOf, "int", "1");
            }
            else
            {
                m.UnfreezeValue(impostorOf); m.WriteMemory(impostorOf, "int", "0");
            }
        }

        private void chkIgnoreWalls_OnChange(object sender, EventArgs e)
        {
            if (chkIgnoreWalls.Checked)
                m.WriteMemory(ignoreWall, "bytes", "72 12");
            else
                m.WriteMemory(ignoreWall, "bytes", "75 12");
        }

        private void chkKillCooldown_OnChange(object sender, EventArgs e)
        {
            if (chkKillCooldown.Checked)
                m.WriteMemory(killCooldown, "bytes", "76 6E");
            else
                m.WriteMemory(killCooldown, "bytes", "77 6E");
        }

        private void chkInfiniteSabotage_OnChange(object sender, EventArgs e)
        {
            if (chkInfiniteSabotage.Checked)
            {
                m.WriteMemory(canUse, "bytes", "B8 01 00 00 00 C3 90 90 90 90");
                m.WriteMemory(sabInf1, "bytes", "C7 47 08 00 00 00 00");
                m.WriteMemory(sabInf2, "bytes", "C7 47 08 00 00 00 00");
                m.WriteMemory(sabInf3, "bytes", "C7 47 08 00 00 00 00");
                m.WriteMemory(sabInf4, "bytes", "C7 47 08 00 00 00 00");
                m.WriteMemory(sabInf5, "bytes", "C7 47 08 00 00 00 00");
            }
            else
            {
                m.WriteMemory(canUse, "bytes", "55 8B EC 80 3D 05 61 BC 63 00");
                m.WriteMemory(sabInf1, "bytes", "C7 47 08 00 00 F0 41");
                m.WriteMemory(sabInf2, "bytes", "C7 47 08 00 00 F0 41");
                m.WriteMemory(sabInf3, "bytes", "C7 47 08 00 00 F0 41");
                m.WriteMemory(sabInf4, "bytes", "C7 47 08 00 00 F0 41");
                m.WriteMemory(sabInf5, "bytes", "C7 47 08 00 00 F0 41");
            }
        }

        private void chkInfiniteRange_OnChange(object sender, EventArgs e)
        {
            byte[] array = { 0xC7, 0x44, 0x06, 0x10, 0x00, 0x00, 0x80, 0x7F, 0xF3, 0x0F, 0x10, 0x44, 0x06, 0x10 };
            if (chkInfiniteRange.Checked)
            {
                m.CreateCodeCave(infRange, array, 6);
                Thread.Sleep(5);
                m.CreateCodeCave(infRange2, array, 6);
                Thread.Sleep(5);
                m.CreateCodeCave(infRange3, array, 6);
                Thread.Sleep(5);
            }
            else
            {
                m.WriteMemory(infRange, "bytes", "F3 0F 10 44 86 10 A1");
                m.WriteMemory(infRange2, "bytes", "F3 0F 10 44 86 10 A1");
                m.WriteMemory(infRange3, "bytes", "F3 0F 10 44 86 10 A1");
            }
        }

        private void chkKillImpostor_OnChange(object sender, EventArgs e)
        {
            if (chkKillImpostor.Checked)
                m.WriteMemory(killImpostor, "bytes", "0F 82 3C 01 00 00 6A 00");
            else
                m.WriteMemory(killImpostor, "bytes", "0F 85 3C 01 00 00 6A 00");
        }

        private void chkTaskImpostor_OnChange(object sender, EventArgs e)
        {
            if (chkTaskImpostor.Checked)
                m.WriteMemory(taskImpostor, "bytes", "80 78 28 05 0F 84");
            else
                m.WriteMemory(taskImpostor, "bytes", "80 78 28 00 0F 85");
        }

        private void chkDoorCooldown_OnChange(object sender, EventArgs e)
        {
            if (chkDoorCooldown.Checked)
            {
                m.WriteMemory(doorCooldown, "bytes", "C7 40 38 00 00 00 00");
                m.WriteMemory(doorCooldown2, "bytes", "F3 0F 11 68 0C FF 46");
            }
            else
            {
                m.WriteMemory(doorCooldown, "bytes", "C7 40 38 00 00 F0 41");
                m.WriteMemory(doorCooldown2, "bytes", "F3 0F 11 40 0C FF 46");
            }
        }

        private void chkSeeImpostor_OnChange(object sender, EventArgs e)
        {
            if (chkSeeImpostor.Checked)
            {
                m.WriteMemory(seeImpostor, "bytes", "80 7B 28 05");
                m.WriteMemory(seeImpostorShh, "bytes", "62 04 00 00 80 7B 28 05");
            }
            else
            {
                m.WriteMemory(seeImpostor, "bytes", "80 7B 28 00");
                m.WriteMemory(seeImpostorShh, "bytes", "62 04 00 00 80 7B 28 00");
            }
        }

        private void chkSuperVision_OnChange(object sender, EventArgs e)
        {
            if (chkSuperVision.Checked)
            {
                byte[] array = { 0x81,0x3C,0xC7,0x00,0x00,0x10,0x40,0x75,0x12,0x0F,0x1F,0x40,0x00,0xC7,0x84,0xC7,0x80,0x04,0x00,0x00,0x00,0x00,0x48,0x42,0x0F,0x59,0xCE,0x0F,0x10,0x04,0xC7,0x0F,0x59,0xCE };//
                m.WriteMemory("UnityPlayer.dll+124BA3", "bytes", "0F 10 04 C7 0F 59 CE");
                Thread.Sleep(50);
                m.CreateCodeCave("UnityPlayer.dll+124BA3", array, 7);

            }
            else
            {
                byte[] array = { 0x81, 0x3C, 0xC7, 0x00, 0x00, 0x10, 0x40, 0x75, 0x12, 0x0F, 0x1F, 0x40, 0x00, 0xC7, 0x84, 0xC7, 0x80, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x59, 0xCE, 0x0F, 0x10, 0x04, 0xC7, 0x0F, 0x59, 0xCE };//
                m.WriteMemory("UnityPlayer.dll+124BA3", "bytes", "0F 10 04 C7 0F 59 CE");
                Thread.Sleep(50);
                m.CreateCodeCave("UnityPlayer.dll+124BA3", array, 7);
            }
        }

        private void chkSeeGhosts_OnChange(object sender, EventArgs e)
        {

            if (chkSeeGhosts.Checked)
                m.WriteMemory(specListGhost, "bytes", "0F 83 D8 01 00 00 A1");
            else
                m.WriteMemory(specListGhost, "bytes", "0F 84 D8 01 00 00 A1");
        }

        private void chkSeeGhostsChat_OnChange(object sender, EventArgs e)
        {

            if (chkSeeGhostsChat.Checked)
                m.WriteMemory(seeGhostChat, "bytes", "80 7E 29 01");
            else
                m.WriteMemory(seeGhostChat, "bytes", "80 7E 29 00");
        }

        private void chkKickAll_OnChange(object sender, EventArgs e)
        {
        }

        private void chkRemoveBanTime_OnChange(object sender, EventArgs e)
        {
            if (chkRemoveBanTime.Checked)
                m.WriteMemory(antiBan, "bytes", "B8 00 00 00 00 C3");
            else
                m.WriteMemory(antiBan, "bytes", "55 8B EC 6A 00 FF");
        }

        private void chkLagSwitch_OnChange(object sender, EventArgs e)
        {
            if (chkLagSwitch.Checked)
                m.FreezeValue(lagSwitch, "int", "0");
            else
            {
                m.UnfreezeValue(lagSwitch);
                m.WriteMemory(lagSwitch, "int", "1");
            }
        }

        private void chkWallhack_OnChange(object sender, EventArgs e)
        {
            if (chkWallhack.Checked)
                m.WriteMemory(wallHack, "bytes", "0F 85");
            else
                m.WriteMemory(wallHack, "bytes", "0F 84");
        }

        private void chkFastChat_OnChange(object sender, EventArgs e)
        {
            if (chkFastChat.Checked)
                m.WriteMemory(fastChat, "bytes", "0xC7 0x46 0x50 0x00 0x00 0x40 0x40");
            else
                m.WriteMemory(fastChat, "bytes", "0xC7 0x46 0x50 0x00 0x00 0x00 0x00");
        }

        private void chkUnlockItems_OnChange(object sender, EventArgs e)
        {
            if (chkUnlockItems.Checked)
            {
                m.WriteMemory(unlockItens, "bytes", "90 90");
                m.WriteMemory(unlockItens2, "bytes", "90 90 90 90 90 90 90 90 90");
            }
            else
                m.WriteMemory(unlockItens, "bytes", "8B D8");
        }

        private void chkDoubleHost_OnChange(object sender, EventArgs e)
        {
            if (chkDoubleHost.Checked)
            {
                temp = m.ReadInt(kickAll);
                temp2 = m.ReadInt(host);
                m.WriteMemory(kickAll, "int", temp2.ToString());
            }
            else
            {
                m.WriteMemory(kickAll, "int", temp.ToString());
            }
        }

        private void chkInfiniteKickVote_OnChange(object sender, EventArgs e)
        {
            if (chkInfiniteKickVote.Checked)
            {
                temp2 = m.ReadInt(host);
                if (!Votes.IsBusy)
                {
                    Votes.RunWorkerAsync();
                }
            }
            else
            {
                m.WriteMemory(host, "int", temp2.ToString());
            }
        }

        private void chkBypassBanRooms_OnChange(object sender, EventArgs e)
        {
        }


        private void Votes_DoWork(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            while (true)
            {
                Thread.Sleep(400);
                if (chkInfiniteKickVote.Checked)
                {
                    int votes = rnd.Next(1, 1000);
                    m.WriteMemory(host, "int", votes.ToString());
                }
                else
                {
                    Votes.WorkerSupportsCancellation = true;
                    Votes.CancelAsync();
                    break;
                }
            }
        }
        private void miscellaneous_Click(object sender, EventArgs e)
        {

        }

        private void notifControl1_Load(object sender, EventArgs e)
        {

        }
        public static string BytesToHexString(byte[] input)
        {
            return input.Aggregate("", (current, b) => current + (b.ToString("X").Length < 2 ? $"0{b:X} " : $"{b:X} ")).TrimEnd(' ');
        }

        private async void chkNukeRoom_OnChange(object sender, EventArgs e)
        {
            if (used == false)
            {
                chkNukeRoom.Checked = false;
                IEnumerable<long> AoBScanResults = await m.AoBScan(0x0000000000000000, 0x7fffffffffffffff, "55 8B EC 80 3D A5 FE", false, true);
                SingleAoBScanResult = AoBScanResults.FirstOrDefault();
                used = true;
                chkNukeRoom.Checked = false;
                return;
            }
            if (chkNukeRoom.Checked && abre == false)
            {
                byte[] shellcode = { 0xE9, 0x2B, 0x2E, 0x0, 0x58, 0x55, 0x8B, 0xEC, 0x83, 0xEC, 0x34 };
                uint where_to_jump = Convert.ToUInt32(SingleAoBScanResult);
                UIntPtr base_address = m.CreateCodeCave(FixedUpdate, shellcode, 6);
                if (base_address != UIntPtr.Zero && where_to_jump != 0)
                {
                    uint offset = where_to_jump - base_address.ToUInt32() - 5;
                    byte[] offset_as_bytes = BitConverter.GetBytes(offset);
                    string offset_as_hex_string = BytesToHexString(offset_as_bytes);
                    m.WriteMemory($"0x{(base_address.ToUInt32() + 1):X8}", "bytes", offset_as_hex_string);
                    abre = true;
                }
                else
                {
                    MessageBox.Show("fail allocation report server pls!");
                    chkNukeRoom.Checked = false;
                }
            }
            else if (!chkNukeRoom.Checked && abre == true)
            {
                abre = false;
                m.WriteMemory(FixedUpdate, "bytes", "55 8B EC 83 EC 34");

            }

        }

        private async void chkSkipAll_OnChange(object sender, EventArgs e)
        {
            byte[] shellcode = { 0x6A, 0x00, 0x57, 0xE8, 0xA8, 0x05, 0x07, 0x72, 0x6A, 0x00, 0xF3, 0x0F, 0x10, 0x87, 0xA0, 0x00, 0x00, 0x00 };
            if (used2 == false)
            {
                chkSkipAll.Checked = false;
                IEnumerable<long> AoBScanResults = await m.AoBScan(0x0000000000000000, 0x7fffffffffffffff, "55 8B EC 53 8B 5D 08 33 D2 56 33 F6 57 8B 4B 60", false, true);
                SingleAoBScanResult2 = AoBScanResults.FirstOrDefault();
                used2 = true;
                chkSkipAll.Checked = false;
                return;
            }
            if (chkSkipAll.Checked && abre2 == false)
            {
                m.WriteMemory(SkipAll2, "byte", "FF");
                uint where_to_call = Convert.ToUInt32(SingleAoBScanResult2);
                where_to_call = where_to_call - 3;
                UIntPtr base_address = m.CreateCodeCave(SkipAll, shellcode, 5);
                if (base_address != UIntPtr.Zero && where_to_call != 0)
                {
                    uint offset = where_to_call - base_address.ToUInt32() - 5;
                    byte[] offset_as_bytes = BitConverter.GetBytes(offset);
                    string offset_as_hex_string = BytesToHexString(offset_as_bytes);
                    m.WriteMemory($"0x{(base_address.ToUInt32() + 4):X8}", "bytes", offset_as_hex_string);
                    m.WriteMemory(SkipAll3, "bytes", "0F 1F 44 00 00");
                    Thread.Sleep(5);
                    abre2 = true;
                }
                else
                {
                    MessageBox.Show("Fail Allocation report server pls!");
                    chkSkipAll.Checked = false;
                }
            }
            else if (!chkSkipAll.Checked && abre2 == true)
            {
                abre2 = false;
                m.WriteMemory(SkipAll, "bytes", "6A 00 F3 0F 10 87 A0 00 00 00");
                m.WriteMemory(SkipAll2, "byte", "FF");
            }

        }
        private void chkInstaKillAll_OnChange(object sender, EventArgs e)
        {
            byte[] shellcode = { 0xC7, 0x43, 0x28, 0x56, 0x02, 0x00, 0x00, 0x8B, 0x40, 0x5C, 0x8B, 0x40, 0x04 };
            if (chkInstaKillAll.Checked)
            {
                m.CreateCodeCave("GameAssembly.dll+B03D93", shellcode, 6);
            }
            else
            {
                m.WriteMemory("GameAssembly.dll+B03D93", "bytes", "8B 40 5C 8B 40 04");
            }
        }
        String helplink;
        private WebClient lwc = new WebClient();
        private WebClient uwc = new WebClient();
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}


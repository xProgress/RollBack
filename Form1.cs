using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RollBack
{
    public partial class Main : Form
    {
        public string[]time = new string[8];
        public string[] days = { "", "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap" };
        public Main()
        {
            InitializeComponent();
            if (File.Exists("folders.cfg") == false)
            {
                FileStream fcreate = File.Open("folders.cfg", FileMode.Create);
                fcreate.Close();
            } 
            if(File.Exists("config.cfg")==false)
            {
                FileStream fcreate = File.Open("config.cfg", FileMode.Create);
                fcreate.Close();
                string set="backupfrequency=1\nbackuphour=00\nbackupmin=00\noldcount=1\nonlymodified=0\nzipbe=1\nfolder=C:\\Users\\Public\\Documents\ncompresslev=10";
                File.WriteAllText("config.cfg", set);
            }
            timer1.Start();
            try
            {
                string[] folders = File.ReadAllText("folders.cfg").Split('\n');
                foreach (string folder in folders)
                {
                    konytvarak.Items.Add(folder);
                }
                datas.settings = File.ReadAllText("config.cfg").Split('\n');
                for (int i = 0; i < datas.settings.Length; i++)
                {
                    string [] s=datas.settings[i].Split('=');
                    datas.settings[i] = s[1];
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime saveNow = DateTime.Now;
            time[0] = saveNow.ToString("yyyy");
            time[1] = saveNow.ToString("MM");
            time[2] = saveNow.ToString("dd");
            time[3] = saveNow.ToString("HH");
            time[4] = saveNow.ToString("mm");
            time[5] = saveNow.ToString("ss");
            time[6] = ((int)System.DateTime.Now.DayOfWeek - (int)System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 1).ToString();
            for (int i = 0; i < 5; i++)
            {
                datas.currentTime[i] = Convert.ToInt32(time[i]);
            }
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(saveNow, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            time[7] = weekNum.ToString();

          //  Console.WriteLine(curr);
            toolStripStatusLabel1.Text = "Aktuális idő: "+time[0]+"."+time[1]+"."+time[2]+" - "+time[3]+":"+time[4]+":"+time[5]+", "+days[Convert.ToInt32(time[6])]+" ("+time[7]+". hét)";
        }

        private void addfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            DialogResult result = fdb.ShowDialog();
            if (fdb.SelectedPath != "")
            {
                string item = (konytvarak.Items.Count + 1) + ".\t" + fdb.SelectedPath;
                konytvarak.Items.Add(item);
                String prev = File.ReadAllText("folders.cfg");
                File.WriteAllText("folders.cfg", prev + "\n" + item);
                //folderName = fdb.SelectedPath;
                //folderbrowser.Text = folderName;
            }
            
        }

        private void removefolder_Click(object sender, EventArgs e)
        {
            string newstring = "";
            this.konytvarak.Items.RemoveAt(this.konytvarak.SelectedIndex);
            for (int i = 0; i < konytvarak.Items.Count;i++ )
            {
                string item=Regex.Replace(konytvarak.Items[i].ToString(),"[0-9].\t","");
                newstring += (i==0 ? "":"\n") + (i+1)+".\t"+item;
            }
            File.WriteAllText("folders.cfg", newstring);
            konytvarak.Items.Clear();
            string[] folders = File.ReadAllText("folders.cfg").Split('\n');
            foreach (string folder in folders)
            {
                konytvarak.Items.Add(folder);
            }
        }

        private void azonnaliBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Enabled = false;
            Form3 f = new Form3();
            f.ShowDialog();

            notifyIcon1.BalloonTipText = "A biztonsági mentés elkészült...";
            notifyIcon1.BalloonTipTitle = "RollBack";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(500);
         //   this.Enabled=true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            /*
               DateTime input = //...
               int delta = DayOfWeek.Monday - input.DayOfWeek;
               DateTime monday = input.AddDays(delta);
             */
            if(File.Exists("last_backup.txt")==false){
                DateTime saveNow = DateTime.Now;
                time[0] = saveNow.ToString("yyyy");
                time[1] = saveNow.ToString("MM");
                time[2] = saveNow.ToString("dd");
                time[3] = saveNow.ToString("HH");
                time[4] = saveNow.ToString("mm");
                time[5] = saveNow.ToString("ss");
                FileStream fcreate = File.Open("last_backup.txt", FileMode.Create);
                fcreate.Close();
                File.WriteAllText("last_backup.txt", time[0] + "," + time[1] + "," + time[2] + "," + time[3] + "," + time[4]);
            }
            string get = File.ReadAllText("last_backup.txt");
            string[] split = get.Split(',');
            for (int i = 0; i < split.Length; i++)
            {
                datas.lastBackup[i] = Convert.ToInt32(split[i]);
            }
            datas.nextBackup(true);
            backtimer.Start();
          }

        private void backtimer_Tick(object sender, EventArgs e)
        {
           // datas.nextBackup();
            nextBackLabel.Text = "Következő mentés: " + datas.nextBack[0] + "." + (datas.nextBack[1] < 10 ? "0" : "") + datas.nextBack[1] + "." + (datas.nextBack[2]<10?"0":"") + datas.nextBack[2] + " - " + (datas.nextBack[3] < 10 ? "0" : "") + datas.nextBack[3] + ":" + (datas.nextBack[4] < 10 ? "0" : "") + datas.nextBack[4];
            if (datas.mustBackup() == true)
            {
                // = datas.currentTime;


                notifyIcon1.BalloonTipText = "A biztonsági mentés elkezdődött...";
                notifyIcon1.BalloonTipTitle = "RollBack";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                
                //datas.lastBackup = datas.currentTime;
                string s = "";
                for (int i = 0; i < 5; i++)
                {
                    s += (s==""?"":",")+Convert.ToInt32(time[i]);
                    datas.lastBackup[i] = Convert.ToInt32(time[i]);
                }
                datas.nextBackup(true);
                File.Delete("last_backup.txt");
                FileStream fcreate = File.Open("last_backup.txt", FileMode.Create);
                fcreate.Close();
                File.WriteAllText("last_backup.txt",s);
                Console.WriteLine("BACK MUST START");
               
                Form3 f = new Form3();
                f.ShowDialog();
                f.Visible = this.Visible;

                notifyIcon1.BalloonTipText = "A biztonsági mentés elkészült...";
                notifyIcon1.BalloonTipTitle = "RollBack";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.BalloonTipText = "Az alkalmazás tovább fut a háttéreben...";
                notifyIcon1.BalloonTipTitle = "RollBack";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
               
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.TopLevel = true;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.TopLevel=true;
        }


       

    }
}

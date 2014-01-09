using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace RollBack
{
    public partial class Settings : Form
    {
        String folderName = "";
        public Settings()
        {
           
            InitializeComponent();

            String line = "";
            try
            {
                using (StreamReader sr = new StreamReader("config.cfg"))
                   {
                       while(null!=(line = sr.ReadLine())){
                        //    Console.WriteLine(line);
                            String[] ar = line.Split('=');
                           switch(ar[0])
                           {
                               case "backupfrequency":
                                   frequency.SelectedIndex = Convert.ToInt32(ar[1]);
                                   break;
                               case "backuphour":
                                   hour.Value=Convert.ToInt32(ar[1]);
                                   break;
                               case "backupmin":
                                   minute.Value = Convert.ToInt32(ar[1]);
                                   break;
                               case "oldcount":
                                   oldbackcount.Value = Convert.ToInt32(ar[1]);
                                   break;
                               case "onlymodified":
                                   onlymodif.Checked = (ar[1] == "0" ? false : true);
                                   break;
                               case "zipbe":
                                   zipbe.Checked = (ar[1] == "0" ? false : true);
                                   break;
                               case "folder":
                                   folderbrowser.Text = ar[1];
                                   break;
                               case "compresslev":
                                   comboBox1.SelectedIndex = Convert.ToInt32(ar[1]);
                                   break;
                           }
                       }
                     }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A beállítástároló nem található: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           String line="";
            try
            {
             /*   using (StreamReader sr = new StreamReader("config.cfg"))
                {
                    /*line="";
                    while(null!=(line = sr.ReadLine())){
                         Console.WriteLine(line);
                        al+=(al!=""?"\n":"")+line;
                    }*/
                    line = "backupfrequency=" + frequency.SelectedIndex.ToString() + "\nbackuphour=" + hour.Value.ToString() + "\nbackupmin=" + minute.Value.ToString() + "\noldcount=" + oldbackcount.Value.ToString() + "\nonlymodified=" + (onlymodif.Checked == true ? '1' : '0')+"\nzipbe="+(zipbe.Checked==true?'1':'0')+"\nfolder="+folderbrowser.Text+"\ncompresslev="+comboBox1.SelectedIndex;
                    FileStream fcreate = File.Open("config.cfg", FileMode.Create);
                    fcreate.Close();
                    File.WriteAllText("config.cfg", line);
                    datas.nextBackup(true);
                    this.Close();
                
           //     }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A beállítástároló nem található: "+ex.Message);
                this.Close();
            }


        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdb = new FolderBrowserDialog();
            DialogResult result = fdb.ShowDialog();
            folderName = fdb.SelectedPath;
            folderbrowser.Text = folderName;
        }

        private void zipbe_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = zipbe.Checked;
            if (zipbe.Checked == true)
            {
                oldbackcount.Enabled = true;
                onlymodif.Checked = false;
               
            }
            else
            {
                oldbackcount.Value = 0;
                oldbackcount.Enabled = false;
            }
           // zipbe.Checked = zipbe.Checked == false ? true : false;
        }

        private void onlymodif_CheckedChanged(object sender, EventArgs e)
        {
            if (onlymodif.Checked == true)
            {
                zipbe.Checked = false;
            }
           // onlymodif.Checked = onlymodif.Checked == false ? true : false;
        }
    }
}

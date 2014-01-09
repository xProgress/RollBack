using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using Ionic.Zip;
using System.Collections;

namespace RollBack
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            datas.isprocess = true;
            datas.setNull();
            datas.started = false;
            string[] folders = File.ReadAllText("folders.cfg").Split('\n');
            string[] settings  = File.ReadAllText("config.cfg").Split('\n');
           // datas.settings = null;
            string thistext = Regex.Replace(folders[0], "[0-9].\t", "");
         //   datas.currproc = thistext+ " ("+GetDirectorySize(thistext)+" Mb)";
       //     proglabel.Text = "0/" + folders.Count();
            
            Thread t = new Thread(delegate() {
                foreach (string d in folders)
                {
                    thistext = Regex.Replace(d, "[0-9].\t", "");
                    datas.totlaSize += GetDirectorySize(thistext);
                }
                datas.started = true;
                foreach (string a in folders)
                {
                    
                    datas.est = 0;
                    datas.thisDone = 0;
                    thistext = Regex.Replace(a, "[0-9].\t", "");
                  //  string[] dest = settings[6].Split('=');
                    string[] currdir = a.Split('\\');
                    datas.thisSize = GetDirectorySize(thistext);
                    datas.zipdone = datas.thisSize;
                        //string[] zipbe = .Split('=');
                        if (datas.settings[5] == "1")
                        {
                           
                        //    string[] coutner = settings[3].Split('=');
                            datas.currproc = "Előző mentések keresése és átnevezése";
                            for (int i = Convert.ToInt32(datas.settings[3])+1; i > 0 ; i--)
                            {
                                string oldname = datas.settings[6] + @"\" + (i - 1) + "_" + currdir[currdir.Length - 1] + ".zip";
                                string newname = datas.settings[6] + @"\" + (i) + "_" + currdir[currdir.Length - 1] + ".zip";
                                if (File.Exists(newname)) File.Delete(newname);
                                if (File.Exists(oldname))
                                {
                                    
                                    File.Move(oldname, newname);
                                }
                            }
                            datas.currproc = "File lista összegyűjtése";


                            addToZIP(thistext, datas.settings[6] + @"\1_" + currdir[currdir.Length - 1] + ".zip");
                            datas.currproc = "Tömörítés befejezve";
                            
                              /*  datas.currproc = "Ideiglenes mappa törlése";
                                try
                                {
                                    Directory.Delete(datas.settings[6] + @"\" + currdir[currdir.Length - 1], true);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Hiba!","Az ideiglenes mappa törlése sikertelen!\n\nHibaüzenet: \n"+ex.Message);
                                }*/
                                if (datas.doneSize == datas.totlaSize)
                                    datas.currproc = "Feladat befejezve";
                            //    else datas.currproc = "Számolás";
                          
                        }
                        else
                        {
                            CopyAll(new DirectoryInfo(thistext), new DirectoryInfo(datas.settings[6] + @"\" + currdir[currdir.Length - 1]));
                            datas.currproc = "Másolás kész";
                        }
                  
                }
                datas.doneSize = datas.totlaSize;
                datas.isprocess = false;
               
            });
            t.Start();
           
        }

        private void addToZIP(String source,String zipname)
        {
            ArrayList map = folderMap(source,"");
//            var regex = new Regex(Regex.Escape("o"));
//            var newText = regex.Replace("Hello World", "Foo", 1);
          //  if (File.Exists(zipname)) File.Delete(zipname);
            using (ZipFile zip = new ZipFile())
                {

                    switch (datas.settings[7])
                    {
                        case "0":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level0;
                            break;
                        case "1":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level1;
                            break;
                        case "2":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level2;
                            break;
                        case "3":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level3;
                            break;
                        case "4":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level4;
                            break;
                        case "5":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level5;
                            break;
                        case "6":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level6;
                            break;
                        case "7":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level7;
                            break;
                        case "8":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level8;
                            break;
                        case "9":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level9;
                            break;
                        case "10":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                            break;
                        case "11":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestSpeed;
                            break;
                        case "12":
                            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                            break;
                    }
                    
                    zip.SaveProgress += SaveProgress;
                    for (long i = 0; i < map.Count; i++)
                    {
                        String[] ex=map[(int)i].ToString().Split('/');
                        datas.currproc = ex[1];
                        zip.AddFile(source+(ex[0]!=""?(@"\"+ex[0]):"")+@"\"+ex[1],ex[0]);
                      //  datas.thisDone+=(new FileInfo(source+(ex[0]!=""?(@"\"+ex[0]):"")+@"\"+ex[1]).Length);
                      //  datas.doneSize+=(new FileInfo(source+(ex[0]!=""?(@"\"+ex[0]):"")+@"\"+ex[1]).Length);
                    }
                    datas.currproc = "ZIP lezárása";
                        // add this map file into the "images" directory in the zip archive
                        // zip.AddFile("c:\\images\\personal\\7440-N49th.png", "images");
                        // add the report into a different directory in the archive
                        //  zip.AddFile("c:\\Reports\\2008-Regional-Sales-Report.pdf", "files");
                        //  zip.AddFile("ReadMe.txt");
                        zip.Save(zipname);
                }
             //   zip.AddDirectory(datas.settings[6] + @"\" + currdir[currdir.Length - 1], "");
             //  zip.Save(datas.settings[6] + @"\1_" + currdir[currdir.Length - 1] + ".zip");

            
        }


        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
             //   MessageBox.Show("Begin Saving: " + e.ArchiveName);
               
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                datas.currproc = "Tömörítés: "+e.CurrentEntry.FileName;
                //progressBar1.Maximum = e.EntriesTotal;
                //progressBar1.Value = e.EntriesSaved + 1;
                datas.thisSize = e.EntriesTotal;
                
                datas.thisDone = e.EntriesSaved + 1;
                datas.doneSize += (double)(datas.zipdone) * (double)(1 / (double)e.EntriesTotal);
            //    labelCompressionStatus.Text = "Writing: " + e.CurrentEntry.FileName + " (" + (e.EntriesSaved + 1) + "/" + e.EntriesTotal + ")";
          //      labelFilename.Text = "Filename:" + e.CurrentEntry.LocalFileName;

            //    progressBar2.Maximum = e.EntriesTotal;
            //    progressBar2.Value = e.EntriesSaved + 1;
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
              //  progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
             //   MessageBox.Show("Done: " + e.ArchiveName);
            }
        }


        private ArrayList folderMap(String foldername,String subfolder)
        {
            ArrayList map = new ArrayList();

            DirectoryInfo dir = new DirectoryInfo((foldername + (subfolder != "" ? (@"\" + subfolder) : "")));
            if (Directory.Exists(foldername + (subfolder != "" ? (@"\" + subfolder) : "")) == false)
            {
                return null;
            }

//            FileInfo[] a = Directory.GetFiles(foldername + (subfolder != "" ? (@"\" + subfolder) : ""), "*.*",SearchOption.AllDirectories);
            Console.WriteLine(dir.ToString());
            foreach (FileInfo fi in dir.GetFiles())
            {
                Console.WriteLine(fi.Name);
                map.Add(subfolder+"/"+fi.Name);
            }
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                ArrayList l = folderMap(foldername, (subfolder != "" ? (subfolder + @"\") : "")+di.Name);
                if(l!=null)
                map.AddRange(l);
            }
            return map;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (datas.started == true)
            {
                datas.counter = (int)((datas.est / datas.thisDone) * (datas.thisSize - datas.thisDone));
                datas.counter = (datas.counter > 0 ? datas.counter : 0);
                long counter = datas.counter;
                int hrleft = (int)(datas.counter / 3600);
                counter -= hrleft * 3600;
                int minleft =(int)(counter / 60);
                counter -= minleft * 60;
                int secleft = (int)counter;
                label5.Text = (hrleft < 10 ? "0" : "") + hrleft + ":" + (minleft < 10 ? "0" : "") + minleft + ":" + (secleft < 10 ? "0" : "") + secleft;

         
                datas.tickCount++;
                if (datas.tickCount > 10)
                {
                    datas.tickCount = 0;
                    datas.est++;
                }
                try
                {
                    progressBar1.Value = (int)((datas.thisDone / datas.thisSize) * 100);
                }
                catch (Exception ex) { }
                label4.Text = (int)((datas.thisDone / datas.thisSize) * 100) + " %";
                //progressBar1.Value = datas.topPerc;
                current_job.Text = datas.currproc;
                try
                {
                    progressBar2.Value = (int)((datas.doneSize / datas.totlaSize) * 100);
                }
                catch (Exception ex) { }

                label3.Text = (int)((((datas.doneSize / 1024) / 1024) / ((datas.totlaSize / 1024) / 1024)) * 100) + " %";
                if (datas.doneSize != datas.totlaSize)
                    proglabel.Text = (int)((datas.doneSize / 1024) / 1024) + " / " + (int)((datas.totlaSize / 1024) / 1024) + " Mb";
                else proglabel.Text = "Feladat befejezve";
                
            }
            if (datas.isprocess == false) this.Close();
        }

        static long GetDirectorySize(string p)
        {
            long b = 0;
            try
            {
                string[] a = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);


                foreach (string name in a)
                {
                    FileInfo info = new FileInfo(name);
                    b += info.Length;
                }
            }
            catch (Exception ex) { MessageBox.Show("HIBA!", "Nem érhető el a " + p + " könyvtár!\n\n" + ex.Message); }
           
            return b;
        }


        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                // Check if the target directory exists, if not, create it.
                if (Directory.Exists(target.FullName) == false)
                {
                    Directory.CreateDirectory(target.FullName);
                }

                // Copy each file into it's new directory.
                foreach (FileInfo fi in source.GetFiles())
                {

                    datas.thisDone += fi.Length;
                    datas.currproc = fi.FullName + "(" + ((fi.Length / 1024) / 1024) + " Mb)";
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    string targetname = target.ToString()+@"\"+fi.Name;
                    if (File.Exists(targetname)&&datas.settings[4]=="1")
                    {
                        FileInfo tar = new FileInfo(targetname);
                        if (tar.LastWriteTimeUtc < fi.LastWriteTimeUtc)
                        {
                            File.Delete(targetname);
                            fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                        }
                    }
                    else
                    {
                        fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
                    }
                    datas.doneSize += fi.Length;
                    //SZámolása: (TimeTaken / linesProcessed) * linesLeft=timeLeft

                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }catch (Exception ex) { MessageBox.Show("HIBA!", "Nem érhető el a " + source + " könyvtár!\n\n" + ex.Message); }
        }
    }
}

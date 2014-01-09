using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RollBack
{
    class datas
    {
        public static bool isprocess = false;
        public static string currproc ="";
        public static string folyamat = "";
        public static int topPerc = 0;
        public static int bottomPerc = 0;
        public static long totlaSize = 0;
        public static double doneSize = 0;
        public static string[] settings = null;
        public static long thisSize = 0;
        public static double thisDone = 0;

        public static long est = 0;
        public static long counter = 0;
        public static int tickCount = 0;
        public static bool started = false;

        public static long zipdone = 0;
        public static long prevzip = 0;
        //ÉÉÉÉ, HH, NN, ÓÓ, PP
        public static int[] lastBackup = { 1900, 1, 1, 0, 0 };
        public static int[] nextBack = { 1900, 1, 1, 0, 0 };
        public static int[] currentTime = { 0, 0, 0, 0, 0 };

        public static void setNull()
        {
            currproc ="";
            folyamat = "";
            topPerc = 0;
            bottomPerc = 0;
            totlaSize = 0;
            doneSize = 0;
           settings = null;
            thisSize = 0;
            thisDone = 0;

            est = 0;
            counter = 0;
            tickCount = 0;
            started = false;

            zipdone = 0;
            prevzip = 0;
            settings = File.ReadAllText("config.cfg").Split('\n');
            for (int i = 0; i < settings.Length; i++)
            {
                string[] s=settings[i].Split('=');
                settings[i] = s[1];
            }
        }

        public static void nextBackup(bool add){
            //if(add==true)
            for (int i = 0; i < 5; i++)
            {
                datas.nextBack[i] = datas.lastBackup[i];
            }
                
         //   int freq = 0;
            string[] settings = File.ReadAllText("config.cfg").Split('\n');
            for (int i = 0; i < settings.Length; i++)
            {
                string[] s = settings[i].Split('=');
                settings[i] = s[1];
            }
            datas.nextBack[3] = Convert.ToInt32(settings[1]);
            datas.nextBack[4] = Convert.ToInt32(settings[2]);
            int daysinMonth = 0;

            daysinMonth = System.DateTime.DaysInMonth(datas.lastBackup[0], datas.lastBackup[1]);
            
           int next = 0;

           Console.Write("Előtte: ");
           for (int i = 0; i < 5;i++ )
               Console.Write(nextBack[i]+"-");

           Console.WriteLine("");
         //  Console.WriteLine(settings[0].GetType().ToString());
            if(add==true)
            switch (settings[0])
            {
                //nap, hét, hó, év
                case "0":
           //         freq
                    Console.WriteLine("Naponta");
                    next = datas.lastBackup[2] + 1;

                    if (next > daysinMonth)
                    {
                        next = next - daysinMonth;
                        datas.nextBack[1] = datas.lastBackup[1] + 1;
                    }

                    if (nextBack[1] > 12)
                    {
                        datas.nextBack[1] = 1;
                        datas.nextBack[0] = datas.lastBackup[0] + 1;
                    }
                    datas.nextBack[2] = next;
                    break;
                case "1":
                    next = datas.lastBackup[2] + 7;

                    if (next > daysinMonth)
                    {
                        next = next - daysinMonth;
                        datas.nextBack[1] = datas.lastBackup[1] + 1;
                    }

                    if (nextBack[1] > 12)
                    {
                        datas.nextBack[1] = 1;
                        datas.nextBack[0] = datas.lastBackup[0] + 1;
                    }

                    datas.nextBack[2] = next;
                    break;
                case "2":
                    datas.nextBack[1] = (datas.lastBackup[1] != 12 ? datas.lastBackup[1] + 1 : 1);
                    break;
                case "3":
                    datas.nextBack[0] = datas.lastBackup[0] + 1;
                    break;
            }
            Console.Write("Utána: ");
            for (int i = 0; i < 5; i++)
                Console.Write(nextBack[i]+"-");
            Console.WriteLine("");
        }

        public static bool mustBackup()
        {
            int must = 0;              
            for (int i = 0; i < 3; i++)
            {
                if (nextBack[i] <= currentTime[i]) must++;
            }
           
            if (must == 3)
            {
                if (nextBack[3] < currentTime[3])
                {
                    must=5;
                }
                else
                {
                    if (nextBack[3] == currentTime[3] && nextBack[4]<=currentTime[4])
                    {
                        must = 5;
                    }
                }
            }
            if (must == 5) return true;
                return false;
        }
        
    }
}

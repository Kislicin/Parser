using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Media;

using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TLSharp.Core;
using TLSharp.Core.Network;
using TLSharp.Core.Requests;
using TLSharp.Core.Utils;


namespace driftparser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool testSite(string url)
        {

            Uri uri = new Uri(url);
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int tick = 3000;
            timer1.Interval = tick;
            timer1.Enabled = true;
        }

        private void playAlarm()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"alarm.wav");
            simpleSound.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            if (testSite("https://rds5.ticketforevent.com/"))
            {
                textBox1.AppendText(Environment.NewLine + localDate.ToString() + " - В продаже!");
                timer1.Enabled = false;
                playAlarm();
                if (MessageBox.Show("Беги покупай!  КУПИТЬ?", "КАРАМБА!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://rds5.ticketforevent.com/");
                }
            } else
            {
                textBox1.AppendText(Environment.NewLine + localDate.ToString() + " - Нет новостей");
            }

            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            textBox1.AppendText(Environment.NewLine + localDate.ToString() + " - В продаже!");
            timer1.Enabled = false;
            playAlarm();
            if (MessageBox.Show("Беги покупай! КУПИТЬ?", "КАРАМБА!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://rds5.ticketforevent.com/");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            var client = new TelegramClient(111, "as34232vxe34sdsd");
            //await client.ConnectAsync();

        }
    }
}

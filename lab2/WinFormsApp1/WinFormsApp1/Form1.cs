using Microsoft.VisualBasic.Devices;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        (Panel, Panel)[] panels;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1_tick(null,null);
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_tick);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = float.TryParse(textBox1.Text,out float o);
            if(res)
            {
                if(res==0.0) {
                    if (timer1.Enabled)
                        timer1.Stop();
                } else {
                    timer1.Interval = (int)(o * 1000);
                    if(!timer1.Enabled)
                        timer1.Start();
                }

            }
            else
            {
                textBox1.Text = "bad string";
            }
        }

        private void timer1_tick(Object sender,EventArgs eventArgs)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("name",typeof(string));
            tbl.Columns.Add("free space",typeof(string));
            var pcinfo = new ComputerInfo();
            label1.Text = "Free RAM: " + (pcinfo.AvailablePhysicalMemory / System.Math.Pow(2, 30)).ToString("0.00") + " GB"; 

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach(DriveInfo drive in drives)
            {
                tbl.Rows.Add(drive.Name,(drive.TotalFreeSpace / System.Math.Pow(2, 30)).ToString("0.00")+"GB");
            }
            dataGridView1.DataBindings.Clear();
            dataGridView1.DataSource = tbl;
        }
    }
}

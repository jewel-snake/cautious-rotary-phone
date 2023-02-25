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

namespace WindowsFormsApp6
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			var text1 = textBox1.Text;
			var text2 = textBox2.Text;
			if(File.Exists(text1))
			{
				if (radioButton1.Checked)
				{ //move
					File.Move(text1, text2);
				}
				else if (radioButton2.Checked)
				{ //copy
					File.Copy(text1, text2);
				}
				else if (radioButton3.Checked)
				{ // rename
					File.Move(text1, text2);
				}
				else
				{
					MessageBox.Show("select mode");
				}
			}
			else
			{
				MessageBox.Show("wrong file name in first folder");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem12
{
	public partial class Form1 : Form
	{
		public static Random random = new Random();

		public Form1()
		{
			InitializeComponent();
			timer1.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

		private void DeleteButton_Click(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.ForeColor = Color.FromArgb(random.Next(256),
				random.Next(256), random.Next(256), random.Next(256));
			//DeleteButton.Location = new Point(random.Next());

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			label1.ForeColor = Color.FromArgb(random.Next(256),
	random.Next(256), random.Next(256), random.Next(256));
			//DeleteButton.Location = new Point(random.Next());
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			button1.Visible = false;
			button2.Visible = true;
			label1.Text = "Button 1 is active";
		}

		private void DeleteButton_Click_1(object sender, EventArgs e)
		{
			button1.Dispose();
			button2.Dispose();
			DeleteButton.Dispose();
			label1.Text = "All buttons disposed";
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			button1.Visible = true;
			button2.Visible = false;
			label1.Text = "Button 2 is active";
		}
	}
}

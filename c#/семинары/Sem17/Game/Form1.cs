using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
	public partial class Form1 : Form
	{
		public int counter;
		public int counterPerSec;
		public int prev;
		public Form1()
		{
			counter = 0;
			counterPerSec = 0;
			prev = 0;
			InitializeComponent();
			timer.Start();
			max.Text = $"Max clicks/sec: {prev}";
		}

		private void click_Click(object sender, EventArgs e)
		{
			counter++;
			counterPerSec++;
			if (counterPerSec>prev)
			{
				prev = counterPerSec;
			}
			count.Text = $"Count: {counter}\nclicks / sec: {counterPerSec}";
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			counterPerSec = 0;
			count.Text = $"Count: {counter}\nclicks / sec: {counterPerSec}";
			max.Text = $"Max clicks/sec: {prev}";
		}
	}
}

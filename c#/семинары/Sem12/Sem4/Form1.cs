using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem4
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			Logger logger = new Logger();
			Battlefield battlefield = new Battlefield(new Battleship(), new Battleship(), logger);
			battlefield.Battle();
			richTextBox1.Text += logger.ReadAll();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{

		}
	}
}

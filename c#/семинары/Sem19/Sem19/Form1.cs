using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem19
{
	public partial class Form1 : Form
	{
		public static Random random = new Random();

		public event EventHandler StyleEvent;

		public readonly StringBuilder result;
		public Form1()
		{
			InitializeComponent();
			result = new StringBuilder();
			StyleEvent += (object sender, EventArgs e) => { BackColor = (e as StyleEventArgs).FormColor; };
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = "Form_Load";
			result.Append("\r\nLoad");
			MessageBox.Show(Text, "Event happened");
		}

		private void Form1_Activated(object sender, EventArgs e)
		{
			this.Text = "Form_Activated";
			result.Append("\r\nActivated");
	//DialogResult fin=		MessageBox.Show(Text, "Event happened", MessageBoxButtons.YesNoCancel);
	//		Text += fin.ToString();
			ChangeStyle();
		}

		private void Form1_Deactivate(object sender, EventArgs e)
		{
			this.Text = "Form_Deactivate";
			result.Append("\r\nDeactivate");
	//		MessageBox.Show(Text, "Event happened");
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{

			
		//	this.Text = "Form_FormClosed";
			result.Append("\r\nFormClosed");
			//MessageBox.Show(Text, "Event happened");
		}

		private void ChangeStyle() {
			StyleEvent?.Invoke(this, new StyleEventArgs(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))));
  }

		private void Form1_Load_1(object sender, EventArgs e)
		{

		}
	}
}

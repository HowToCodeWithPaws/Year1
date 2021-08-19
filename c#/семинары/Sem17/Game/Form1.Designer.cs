namespace Game
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.click = new System.Windows.Forms.Label();
			this.count = new System.Windows.Forms.Label();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.max = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// click
			// 
			this.click.AutoSize = true;
			this.click.Location = new System.Drawing.Point(362, 196);
			this.click.Name = "click";
			this.click.Size = new System.Drawing.Size(79, 20);
			this.click.TabIndex = 0;
			this.click.Text = "click here!";
			this.click.Click += new System.EventHandler(this.click_Click);
			// 
			// count
			// 
			this.count.AutoSize = true;
			this.count.Location = new System.Drawing.Point(84, 62);
			this.count.Name = "count";
			this.count.Size = new System.Drawing.Size(80, 40);
			this.count.TabIndex = 1;
			this.count.Text = "Count:\r\nclicks/sec:";
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// max
			// 
			this.max.AutoSize = true;
			this.max.Location = new System.Drawing.Point(587, 72);
			this.max.Name = "max";
			this.max.Size = new System.Drawing.Size(117, 20);
			this.max.TabIndex = 2;
			this.max.Text = "Max clicks/sec: ";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.max);
			this.Controls.Add(this.count);
			this.Controls.Add(this.click);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label click;
		private System.Windows.Forms.Label count;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label max;
	}
}


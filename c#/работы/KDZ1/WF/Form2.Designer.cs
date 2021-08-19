namespace WF
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.moveMessage = new System.Windows.Forms.Label();
			this.choiceTheAttacking = new System.Windows.Forms.ListBox();
			this.pickTheAttacking = new System.Windows.Forms.RichTextBox();
			this.pickTheDefending = new System.Windows.Forms.RichTextBox();
			this.choiceTheDefending = new System.Windows.Forms.ListBox();
			this.theAttacking = new System.Windows.Forms.Button();
			this.transferConfirm = new System.Windows.Forms.Button();
			this.transferCargo = new System.Windows.Forms.TextBox();
			this.theDefending = new System.Windows.Forms.Button();
			this.attack = new System.Windows.Forms.Button();
			this.transferChoice = new System.Windows.Forms.Button();
			this.transferRefuse = new System.Windows.Forms.Button();
			this.attackResults = new System.Windows.Forms.RichTextBox();
			this.proceed = new System.Windows.Forms.Button();
			this.exit = new System.Windows.Forms.Button();
			this.newMoveWOAttacking = new System.Windows.Forms.Button();
			this.newMoveWODefending = new System.Windows.Forms.Button();
			this.newMove = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// moveMessage
			// 
			this.moveMessage.AutoSize = true;
			this.moveMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.moveMessage.ForeColor = System.Drawing.Color.Blue;
			this.moveMessage.Location = new System.Drawing.Point(17, 27);
			this.moveMessage.Name = "moveMessage";
			this.moveMessage.Size = new System.Drawing.Size(0, 20);
			this.moveMessage.TabIndex = 0;
			// 
			// choiceTheAttacking
			// 
			this.choiceTheAttacking.FormattingEnabled = true;
			this.choiceTheAttacking.ItemHeight = 20;
			this.choiceTheAttacking.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
			this.choiceTheAttacking.Location = new System.Drawing.Point(689, 59);
			this.choiceTheAttacking.Name = "choiceTheAttacking";
			this.choiceTheAttacking.Size = new System.Drawing.Size(69, 104);
			this.choiceTheAttacking.TabIndex = 1;
			// 
			// pickTheAttacking
			// 
			this.pickTheAttacking.Location = new System.Drawing.Point(12, 59);
			this.pickTheAttacking.Name = "pickTheAttacking";
			this.pickTheAttacking.ReadOnly = true;
			this.pickTheAttacking.Size = new System.Drawing.Size(660, 250);
			this.pickTheAttacking.TabIndex = 2;
			this.pickTheAttacking.Text = "";
			// 
			// pickTheDefending
			// 
			this.pickTheDefending.Location = new System.Drawing.Point(12, 431);
			this.pickTheDefending.Name = "pickTheDefending";
			this.pickTheDefending.ReadOnly = true;
			this.pickTheDefending.Size = new System.Drawing.Size(660, 250);
			this.pickTheDefending.TabIndex = 3;
			this.pickTheDefending.Text = "";
			this.pickTheDefending.Visible = false;
			// 
			// choiceTheDefending
			// 
			this.choiceTheDefending.FormattingEnabled = true;
			this.choiceTheDefending.ItemHeight = 20;
			this.choiceTheDefending.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
			this.choiceTheDefending.Location = new System.Drawing.Point(689, 431);
			this.choiceTheDefending.Name = "choiceTheDefending";
			this.choiceTheDefending.Size = new System.Drawing.Size(69, 104);
			this.choiceTheDefending.TabIndex = 4;
			this.choiceTheDefending.Visible = false;
			// 
			// theAttacking
			// 
			this.theAttacking.BackColor = System.Drawing.Color.LightGreen;
			this.theAttacking.Location = new System.Drawing.Point(689, 169);
			this.theAttacking.Name = "theAttacking";
			this.theAttacking.Size = new System.Drawing.Size(99, 37);
			this.theAttacking.TabIndex = 5;
			this.theAttacking.Text = "выбор";
			this.theAttacking.UseVisualStyleBackColor = false;
			this.theAttacking.Click += new System.EventHandler(this.theAttacking_Click);
			// 
			// transferConfirm
			// 
			this.transferConfirm.BackColor = System.Drawing.Color.LightGreen;
			this.transferConfirm.Location = new System.Drawing.Point(652, 375);
			this.transferConfirm.Name = "transferConfirm";
			this.transferConfirm.Size = new System.Drawing.Size(136, 34);
			this.transferConfirm.TabIndex = 6;
			this.transferConfirm.Text = "переместить";
			this.transferConfirm.UseVisualStyleBackColor = false;
			this.transferConfirm.Visible = false;
			this.transferConfirm.Click += new System.EventHandler(this.transferConfirm_Click);
			// 
			// transferCargo
			// 
			this.transferCargo.Location = new System.Drawing.Point(652, 328);
			this.transferCargo.Name = "transferCargo";
			this.transferCargo.Size = new System.Drawing.Size(136, 26);
			this.transferCargo.TabIndex = 8;
			this.transferCargo.Visible = false;
			// 
			// theDefending
			// 
			this.theDefending.BackColor = System.Drawing.Color.LightGreen;
			this.theDefending.Location = new System.Drawing.Point(689, 561);
			this.theDefending.Name = "theDefending";
			this.theDefending.Size = new System.Drawing.Size(99, 35);
			this.theDefending.TabIndex = 9;
			this.theDefending.Text = "выбор";
			this.theDefending.UseVisualStyleBackColor = false;
			this.theDefending.Visible = false;
			this.theDefending.Click += new System.EventHandler(this.theDefending_Click);
			// 
			// attack
			// 
			this.attack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.attack.ForeColor = System.Drawing.Color.Maroon;
			this.attack.Location = new System.Drawing.Point(819, 569);
			this.attack.Name = "attack";
			this.attack.Size = new System.Drawing.Size(223, 59);
			this.attack.TabIndex = 10;
			this.attack.Text = "АТАКОВАТЬ";
			this.attack.UseVisualStyleBackColor = false;
			this.attack.Visible = false;
			this.attack.Click += new System.EventHandler(this.attack_Click);
			// 
			// transferChoice
			// 
			this.transferChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.transferChoice.Location = new System.Drawing.Point(12, 328);
			this.transferChoice.Name = "transferChoice";
			this.transferChoice.Size = new System.Drawing.Size(510, 81);
			this.transferChoice.TabIndex = 11;
			this.transferChoice.Text = "В вашем флоте есть грузовое судно. Припасы с него можно перегрузить на атакующий " +
    "корабль. Если хотите это сделать, нажмите сюда";
			this.transferChoice.UseVisualStyleBackColor = false;
			this.transferChoice.Visible = false;
			this.transferChoice.Click += new System.EventHandler(this.transferChoice_Click);
			// 
			// transferRefuse
			// 
			this.transferRefuse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.transferRefuse.Location = new System.Drawing.Point(528, 328);
			this.transferRefuse.Name = "transferRefuse";
			this.transferRefuse.Size = new System.Drawing.Size(118, 81);
			this.transferRefuse.TabIndex = 12;
			this.transferRefuse.Text = "иначе нажмите сюда";
			this.transferRefuse.UseVisualStyleBackColor = false;
			this.transferRefuse.Visible = false;
			this.transferRefuse.Click += new System.EventHandler(this.transferRefuse_Click);
			// 
			// attackResults
			// 
			this.attackResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.attackResults.Location = new System.Drawing.Point(794, 59);
			this.attackResults.Name = "attackResults";
			this.attackResults.ReadOnly = true;
			this.attackResults.Size = new System.Drawing.Size(452, 365);
			this.attackResults.TabIndex = 14;
			this.attackResults.Text = "";
			this.attackResults.Visible = false;
			// 
			// proceed
			// 
			this.proceed.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.proceed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.proceed.Location = new System.Drawing.Point(949, 569);
			this.proceed.Name = "proceed";
			this.proceed.Size = new System.Drawing.Size(187, 55);
			this.proceed.TabIndex = 15;
			this.proceed.Text = "продолжить";
			this.proceed.UseVisualStyleBackColor = false;
			this.proceed.Visible = false;
			this.proceed.Click += new System.EventHandler(this.proceed_Click);
			// 
			// exit
			// 
			this.exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.exit.ForeColor = System.Drawing.Color.Navy;
			this.exit.Location = new System.Drawing.Point(441, 539);
			this.exit.Name = "exit";
			this.exit.Size = new System.Drawing.Size(258, 78);
			this.exit.TabIndex = 16;
			this.exit.Text = "ПРОДОЛЖИТЬ";
			this.exit.UseVisualStyleBackColor = false;
			this.exit.Visible = false;
			this.exit.Click += new System.EventHandler(this.exit_Click);
			// 
			// newMoveWOAttacking
			// 
			this.newMoveWOAttacking.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.newMoveWOAttacking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.newMoveWOAttacking.Location = new System.Drawing.Point(949, 569);
			this.newMoveWOAttacking.Name = "newMoveWOAttacking";
			this.newMoveWOAttacking.Size = new System.Drawing.Size(187, 58);
			this.newMoveWOAttacking.TabIndex = 17;
			this.newMoveWOAttacking.Text = "продолжить";
			this.newMoveWOAttacking.UseVisualStyleBackColor = false;
			this.newMoveWOAttacking.Visible = false;
			this.newMoveWOAttacking.Click += new System.EventHandler(this.newMoveWOAttacking_Click);
			// 
			// newMoveWODefending
			// 
			this.newMoveWODefending.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.newMoveWODefending.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.newMoveWODefending.Location = new System.Drawing.Point(949, 568);
			this.newMoveWODefending.Name = "newMoveWODefending";
			this.newMoveWODefending.Size = new System.Drawing.Size(187, 58);
			this.newMoveWODefending.TabIndex = 18;
			this.newMoveWODefending.Text = "продолжить";
			this.newMoveWODefending.UseVisualStyleBackColor = false;
			this.newMoveWODefending.Visible = false;
			this.newMoveWODefending.Click += new System.EventHandler(this.newMoveWODefending_Click);
			// 
			// newMove
			// 
			this.newMove.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.newMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.newMove.ForeColor = System.Drawing.SystemColors.ControlText;
			this.newMove.Location = new System.Drawing.Point(949, 569);
			this.newMove.Name = "newMove";
			this.newMove.Size = new System.Drawing.Size(187, 56);
			this.newMove.TabIndex = 19;
			this.newMove.Text = "продолжить";
			this.newMove.UseVisualStyleBackColor = false;
			this.newMove.Visible = false;
			this.newMove.Click += new System.EventHandler(this.newMove_Click);
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1258, 744);
			this.Controls.Add(this.newMove);
			this.Controls.Add(this.newMoveWODefending);
			this.Controls.Add(this.newMoveWOAttacking);
			this.Controls.Add(this.exit);
			this.Controls.Add(this.proceed);
			this.Controls.Add(this.attackResults);
			this.Controls.Add(this.transferRefuse);
			this.Controls.Add(this.transferChoice);
			this.Controls.Add(this.attack);
			this.Controls.Add(this.theDefending);
			this.Controls.Add(this.transferCargo);
			this.Controls.Add(this.transferConfirm);
			this.Controls.Add(this.theAttacking);
			this.Controls.Add(this.choiceTheDefending);
			this.Controls.Add(this.pickTheDefending);
			this.Controls.Add(this.pickTheAttacking);
			this.Controls.Add(this.choiceTheAttacking);
			this.Controls.Add(this.moveMessage);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label moveMessage;
		private System.Windows.Forms.ListBox choiceTheAttacking;
		private System.Windows.Forms.RichTextBox pickTheAttacking;
		private System.Windows.Forms.RichTextBox pickTheDefending;
		private System.Windows.Forms.ListBox choiceTheDefending;
		private System.Windows.Forms.Button theAttacking;
		private System.Windows.Forms.Button transferConfirm;
		private System.Windows.Forms.TextBox transferCargo;
		private System.Windows.Forms.Button theDefending;
		private System.Windows.Forms.Button attack;
		private System.Windows.Forms.Button transferChoice;
		private System.Windows.Forms.Button transferRefuse;
		private System.Windows.Forms.RichTextBox attackResults;
		private System.Windows.Forms.Button proceed;
		private System.Windows.Forms.Button exit;
		private System.Windows.Forms.Button newMoveWOAttacking;
		private System.Windows.Forms.Button newMoveWODefending;
		private System.Windows.Forms.Button newMove;
	}
}
namespace WF
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
			this.bigText = new System.Windows.Forms.Label();
			this.player1Message = new System.Windows.Forms.Label();
			this.player2Message = new System.Windows.Forms.Label();
			this.player2Info = new System.Windows.Forms.TextBox();
			this.player1Info = new System.Windows.Forms.TextBox();
			this.begin = new System.Windows.Forms.Button();
			this.proceed = new System.Windows.Forms.Button();
			this.player1Choice = new System.Windows.Forms.ListBox();
			this.player1Add = new System.Windows.Forms.Button();
			this.player2Choice = new System.Windows.Forms.ListBox();
			this.player2Add = new System.Windows.Forms.Button();
			this.player2ChoiceMessage = new System.Windows.Forms.Label();
			this.player1ChoiceMessage = new System.Windows.Forms.Label();
			this.player1NameChoice = new System.Windows.Forms.Button();
			this.player2NameChoice = new System.Windows.Forms.Button();
			this.player2CurrentChoice = new System.Windows.Forms.Label();
			this.player1CurrentChoice = new System.Windows.Forms.Label();
			this.battleBegin = new System.Windows.Forms.Button();
			this.player1InfoBox = new System.Windows.Forms.RichTextBox();
			this.player2InfoBox = new System.Windows.Forms.RichTextBox();
			this.battle = new System.Windows.Forms.Button();
			this.moveMessage = new System.Windows.Forms.Label();
			this.playAgain = new System.Windows.Forms.Button();
			this.finish = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bigText
			// 
			this.bigText.AutoSize = true;
			this.bigText.BackColor = System.Drawing.Color.Navy;
			this.bigText.Font = new System.Drawing.Font("Stencil", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bigText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.bigText.Location = new System.Drawing.Point(345, 82);
			this.bigText.Name = "bigText";
			this.bigText.Size = new System.Drawing.Size(565, 32);
			this.bigText.TabIndex = 0;
			this.bigText.Text = "~~~~ДОБРО ПОЖАЛОВАТЬ В ИГРУ~~~~";
			this.bigText.Visible = false;
			// 
			// player1Message
			// 
			this.player1Message.AutoSize = true;
			this.player1Message.ForeColor = System.Drawing.Color.Fuchsia;
			this.player1Message.Location = new System.Drawing.Point(22, 21);
			this.player1Message.Name = "player1Message";
			this.player1Message.Size = new System.Drawing.Size(0, 20);
			this.player1Message.TabIndex = 1;
			this.player1Message.Visible = false;
			// 
			// player2Message
			// 
			this.player2Message.AutoSize = true;
			this.player2Message.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.player2Message.Location = new System.Drawing.Point(753, 21);
			this.player2Message.Name = "player2Message";
			this.player2Message.Size = new System.Drawing.Size(0, 20);
			this.player2Message.TabIndex = 2;
			this.player2Message.Visible = false;
			// 
			// player2Info
			// 
			this.player2Info.Location = new System.Drawing.Point(900, 284);
			this.player2Info.Name = "player2Info";
			this.player2Info.Size = new System.Drawing.Size(100, 26);
			this.player2Info.TabIndex = 3;
			this.player2Info.Visible = false;
			// 
			// player1Info
			// 
			this.player1Info.Location = new System.Drawing.Point(224, 284);
			this.player1Info.Name = "player1Info";
			this.player1Info.Size = new System.Drawing.Size(100, 26);
			this.player1Info.TabIndex = 4;
			this.player1Info.Visible = false;
			// 
			// begin
			// 
			this.begin.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.begin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.begin.Location = new System.Drawing.Point(507, 173);
			this.begin.Name = "begin";
			this.begin.Size = new System.Drawing.Size(218, 118);
			this.begin.TabIndex = 5;
			this.begin.Text = "НАЧАТЬ ИГРУ";
			this.begin.UseVisualStyleBackColor = false;
			this.begin.Visible = false;
			this.begin.Click += new System.EventHandler(this.begin_Click);
			// 
			// proceed
			// 
			this.proceed.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.proceed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.proceed.ForeColor = System.Drawing.Color.Navy;
			this.proceed.Location = new System.Drawing.Point(507, 313);
			this.proceed.Name = "proceed";
			this.proceed.Size = new System.Drawing.Size(218, 75);
			this.proceed.TabIndex = 7;
			this.proceed.Text = "ПРОДОЛЖИТЬ";
			this.proceed.UseVisualStyleBackColor = false;
			this.proceed.Visible = false;
			this.proceed.Click += new System.EventHandler(this.proceed_Click);
			// 
			// player1Choice
			// 
			this.player1Choice.FormattingEnabled = true;
			this.player1Choice.ItemHeight = 20;
			this.player1Choice.Items.AddRange(new object[] {
            "эсминец",
            "линкор",
            "грузовое судно"});
			this.player1Choice.Location = new System.Drawing.Point(22, 561);
			this.player1Choice.Name = "player1Choice";
			this.player1Choice.Size = new System.Drawing.Size(166, 84);
			this.player1Choice.TabIndex = 8;
			this.player1Choice.Visible = false;
			// 
			// player1Add
			// 
			this.player1Add.BackColor = System.Drawing.Color.LightGreen;
			this.player1Add.Location = new System.Drawing.Point(212, 561);
			this.player1Add.Name = "player1Add";
			this.player1Add.Size = new System.Drawing.Size(246, 84);
			this.player1Add.TabIndex = 9;
			this.player1Add.Text = "добавить корабль";
			this.player1Add.UseVisualStyleBackColor = false;
			this.player1Add.Visible = false;
			this.player1Add.Click += new System.EventHandler(this.player1Add_Click);
			// 
			// player2Choice
			// 
			this.player2Choice.FormattingEnabled = true;
			this.player2Choice.ItemHeight = 20;
			this.player2Choice.Items.AddRange(new object[] {
            "эсминец",
            "линкор",
            "грузовое судно"});
			this.player2Choice.Location = new System.Drawing.Point(753, 561);
			this.player2Choice.Name = "player2Choice";
			this.player2Choice.Size = new System.Drawing.Size(157, 84);
			this.player2Choice.TabIndex = 10;
			this.player2Choice.Visible = false;
			// 
			// player2Add
			// 
			this.player2Add.BackColor = System.Drawing.Color.LightGreen;
			this.player2Add.Location = new System.Drawing.Point(934, 561);
			this.player2Add.Name = "player2Add";
			this.player2Add.Size = new System.Drawing.Size(224, 84);
			this.player2Add.TabIndex = 11;
			this.player2Add.Text = "добавить корабль";
			this.player2Add.UseVisualStyleBackColor = false;
			this.player2Add.Visible = false;
			this.player2Add.Click += new System.EventHandler(this.player2Add_Click);
			// 
			// player2ChoiceMessage
			// 
			this.player2ChoiceMessage.Location = new System.Drawing.Point(753, 47);
			this.player2ChoiceMessage.Name = "player2ChoiceMessage";
			this.player2ChoiceMessage.Size = new System.Drawing.Size(463, 406);
			this.player2ChoiceMessage.TabIndex = 12;
			this.player2ChoiceMessage.Text = "Вам нужно выбрать 5 кораблей для вашего флота\r\nВы можете купить только одно грузо" +
    "вое судно\r\nКаждый корабль стоит 8 монет\r\n";
			this.player2ChoiceMessage.Visible = false;
			// 
			// player1ChoiceMessage
			// 
			this.player1ChoiceMessage.Location = new System.Drawing.Point(12, 47);
			this.player1ChoiceMessage.Name = "player1ChoiceMessage";
			this.player1ChoiceMessage.Size = new System.Drawing.Size(484, 406);
			this.player1ChoiceMessage.TabIndex = 13;
			this.player1ChoiceMessage.Text = "Вам нужно выбрать 5 кораблей для вашего флота\r\nВы можете купить только одно грузо" +
    "вое судно\r\nКаждый корабль стоит 8 монет\r\n";
			this.player1ChoiceMessage.Visible = false;
			// 
			// player1NameChoice
			// 
			this.player1NameChoice.BackColor = System.Drawing.Color.LightGreen;
			this.player1NameChoice.Location = new System.Drawing.Point(224, 330);
			this.player1NameChoice.Name = "player1NameChoice";
			this.player1NameChoice.Size = new System.Drawing.Size(100, 41);
			this.player1NameChoice.TabIndex = 14;
			this.player1NameChoice.Text = "готово";
			this.player1NameChoice.UseVisualStyleBackColor = false;
			this.player1NameChoice.Visible = false;
			this.player1NameChoice.Click += new System.EventHandler(this.player1NameChoice_Click);
			// 
			// player2NameChoice
			// 
			this.player2NameChoice.BackColor = System.Drawing.Color.LightGreen;
			this.player2NameChoice.Location = new System.Drawing.Point(900, 332);
			this.player2NameChoice.Name = "player2NameChoice";
			this.player2NameChoice.Size = new System.Drawing.Size(100, 39);
			this.player2NameChoice.TabIndex = 15;
			this.player2NameChoice.Text = "готово";
			this.player2NameChoice.UseVisualStyleBackColor = false;
			this.player2NameChoice.Visible = false;
			this.player2NameChoice.Click += new System.EventHandler(this.player2NameChoice_Click);
			// 
			// player2CurrentChoice
			// 
			this.player2CurrentChoice.AutoSize = true;
			this.player2CurrentChoice.Location = new System.Drawing.Point(753, 459);
			this.player2CurrentChoice.Name = "player2CurrentChoice";
			this.player2CurrentChoice.Size = new System.Drawing.Size(0, 20);
			this.player2CurrentChoice.TabIndex = 16;
			// 
			// player1CurrentChoice
			// 
			this.player1CurrentChoice.AutoSize = true;
			this.player1CurrentChoice.Location = new System.Drawing.Point(18, 459);
			this.player1CurrentChoice.Name = "player1CurrentChoice";
			this.player1CurrentChoice.Size = new System.Drawing.Size(0, 20);
			this.player1CurrentChoice.TabIndex = 17;
			// 
			// battleBegin
			// 
			this.battleBegin.BackColor = System.Drawing.Color.DodgerBlue;
			this.battleBegin.Location = new System.Drawing.Point(507, 313);
			this.battleBegin.Name = "battleBegin";
			this.battleBegin.Size = new System.Drawing.Size(218, 75);
			this.battleBegin.TabIndex = 18;
			this.battleBegin.Text = "ПРОДОЛЖИТЬ";
			this.battleBegin.UseVisualStyleBackColor = false;
			this.battleBegin.Visible = false;
			this.battleBegin.Click += new System.EventHandler(this.battleBegin_Click);
			// 
			// player1InfoBox
			// 
			this.player1InfoBox.Location = new System.Drawing.Point(16, 47);
			this.player1InfoBox.Name = "player1InfoBox";
			this.player1InfoBox.ReadOnly = true;
			this.player1InfoBox.Size = new System.Drawing.Size(460, 598);
			this.player1InfoBox.TabIndex = 19;
			this.player1InfoBox.Text = "";
			this.player1InfoBox.Visible = false;
			// 
			// player2InfoBox
			// 
			this.player2InfoBox.Location = new System.Drawing.Point(753, 44);
			this.player2InfoBox.Name = "player2InfoBox";
			this.player2InfoBox.ReadOnly = true;
			this.player2InfoBox.Size = new System.Drawing.Size(463, 601);
			this.player2InfoBox.TabIndex = 20;
			this.player2InfoBox.Text = "";
			this.player2InfoBox.Visible = false;
			// 
			// battle
			// 
			this.battle.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.battle.Font = new System.Drawing.Font("Agency FB", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.battle.Location = new System.Drawing.Point(507, 386);
			this.battle.Name = "battle";
			this.battle.Size = new System.Drawing.Size(218, 67);
			this.battle.TabIndex = 21;
			this.battle.Text = "НАЧАТЬ БОЙ";
			this.battle.UseVisualStyleBackColor = false;
			this.battle.Visible = false;
			this.battle.Click += new System.EventHandler(this.battle_Click);
			// 
			// moveMessage
			// 
			this.moveMessage.AutoSize = true;
			this.moveMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.moveMessage.Location = new System.Drawing.Point(324, 24);
			this.moveMessage.Name = "moveMessage";
			this.moveMessage.Size = new System.Drawing.Size(0, 20);
			this.moveMessage.TabIndex = 22;
			// 
			// playAgain
			// 
			this.playAgain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.playAgain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.playAgain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
			this.playAgain.Location = new System.Drawing.Point(507, 386);
			this.playAgain.Name = "playAgain";
			this.playAgain.Size = new System.Drawing.Size(218, 67);
			this.playAgain.TabIndex = 23;
			this.playAgain.Text = "новая игра";
			this.playAgain.UseVisualStyleBackColor = false;
			this.playAgain.Visible = false;
			this.playAgain.Click += new System.EventHandler(this.playAgain_Click);
			// 
			// finish
			// 
			this.finish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.finish.ForeColor = System.Drawing.Color.DarkRed;
			this.finish.Location = new System.Drawing.Point(507, 473);
			this.finish.Name = "finish";
			this.finish.Size = new System.Drawing.Size(218, 52);
			this.finish.TabIndex = 24;
			this.finish.Text = "выйти из игры";
			this.finish.UseVisualStyleBackColor = false;
			this.finish.Visible = false;
			this.finish.Click += new System.EventHandler(this.finish_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1258, 744);
			this.Controls.Add(this.finish);
			this.Controls.Add(this.playAgain);
			this.Controls.Add(this.moveMessage);
			this.Controls.Add(this.battle);
			this.Controls.Add(this.player2InfoBox);
			this.Controls.Add(this.player1InfoBox);
			this.Controls.Add(this.player2Add);
			this.Controls.Add(this.player2Choice);
			this.Controls.Add(this.player1Add);
			this.Controls.Add(this.player1Choice);
			this.Controls.Add(this.battleBegin);
			this.Controls.Add(this.player1CurrentChoice);
			this.Controls.Add(this.player2CurrentChoice);
			this.Controls.Add(this.player2NameChoice);
			this.Controls.Add(this.player1NameChoice);
			this.Controls.Add(this.player1ChoiceMessage);
			this.Controls.Add(this.player2ChoiceMessage);
			this.Controls.Add(this.proceed);
			this.Controls.Add(this.begin);
			this.Controls.Add(this.player1Info);
			this.Controls.Add(this.player2Info);
			this.Controls.Add(this.player2Message);
			this.Controls.Add(this.player1Message);
			this.Controls.Add(this.bigText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label bigText;
		private System.Windows.Forms.Label player1Message;
		private System.Windows.Forms.Label player2Message;
		private System.Windows.Forms.TextBox player2Info;
		private System.Windows.Forms.TextBox player1Info;
		private System.Windows.Forms.Button begin;
		private System.Windows.Forms.Button proceed;
		private System.Windows.Forms.ListBox player1Choice;
		private System.Windows.Forms.Button player1Add;
		private System.Windows.Forms.ListBox player2Choice;
		private System.Windows.Forms.Button player2Add;
		private System.Windows.Forms.Label player2ChoiceMessage;
		private System.Windows.Forms.Label player1ChoiceMessage;
		private System.Windows.Forms.Button player1NameChoice;
		private System.Windows.Forms.Button player2NameChoice;
		private System.Windows.Forms.Label player2CurrentChoice;
		private System.Windows.Forms.Label player1CurrentChoice;
		private System.Windows.Forms.Button battleBegin;
		private System.Windows.Forms.RichTextBox player1InfoBox;
		private System.Windows.Forms.RichTextBox player2InfoBox;
		private System.Windows.Forms.Button battle;
		private System.Windows.Forms.Label moveMessage;
		private System.Windows.Forms.Button playAgain;
		private System.Windows.Forms.Button finish;
	}
}


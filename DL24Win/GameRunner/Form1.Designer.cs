namespace GameRunner
{
	partial class Form1
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
			this.btnPlayGame = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnPlayGame
			// 
			this.btnPlayGame.Location = new System.Drawing.Point(22, 12);
			this.btnPlayGame.Name = "btnPlayGame";
			this.btnPlayGame.Size = new System.Drawing.Size(167, 73);
			this.btnPlayGame.TabIndex = 0;
			this.btnPlayGame.Text = "Play Game";
			this.btnPlayGame.UseVisualStyleBackColor = true;
			this.btnPlayGame.Click += new System.EventHandler(this.btnPlayGame_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(22, 91);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(810, 497);
			this.textBox1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(917, 600);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnPlayGame);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPlayGame;
		private System.Windows.Forms.TextBox textBox1;
	}
}


namespace lab1tables
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
			this.button1 = new System.Windows.Forms.Button();
			this.Pareto = new System.Windows.Forms.PictureBox();
			this.Slayter = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.Pareto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Slayter)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(889, 526);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Pareto
			// 
			this.Pareto.Location = new System.Drawing.Point(25, 25);
			this.Pareto.Name = "Pareto";
			this.Pareto.Size = new System.Drawing.Size(500, 500);
			this.Pareto.TabIndex = 1;
			this.Pareto.TabStop = false;
			this.Pareto.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// Slayter
			// 
			this.Slayter.Location = new System.Drawing.Point(550, 25);
			this.Slayter.Name = "Slayter";
			this.Slayter.Size = new System.Drawing.Size(500, 500);
			this.Slayter.TabIndex = 2;
			this.Slayter.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 561);
			this.Controls.Add(this.Slayter);
			this.Controls.Add(this.Pareto);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.Pareto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Slayter)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox Pareto;
		private System.Windows.Forms.PictureBox Slayter;
	}
}


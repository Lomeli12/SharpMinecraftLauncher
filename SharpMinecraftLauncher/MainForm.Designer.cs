namespace SharpMinecraftLauncher
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.logintextbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.passwordtextbox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(201, 67);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Login";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// logintextbox
			// 
			this.logintextbox.Location = new System.Drawing.Point(76, 15);
			this.logintextbox.Name = "logintextbox";
			this.logintextbox.Size = new System.Drawing.Size(200, 20);
			this.logintextbox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password:";
			// 
			// passwordtextbox
			// 
			this.passwordtextbox.Location = new System.Drawing.Point(76, 41);
			this.passwordtextbox.Name = "passwordtextbox";
			this.passwordtextbox.Size = new System.Drawing.Size(200, 20);
			this.passwordtextbox.TabIndex = 4;
			this.passwordtextbox.UseSystemPasswordChar = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(264, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "label3";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(285, 130);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.passwordtextbox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.logintextbox);
			this.Controls.Add(this.button1);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "SharpMinecraftLauncher";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox passwordtextbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox logintextbox;
		private System.Windows.Forms.Button button1;
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace SharpMinecraftLauncher
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		string user;
		string pass;
		void Button1Click(object sender, EventArgs e)
		{
			user = logintextbox.Text;
			pass = passwordtextbox.Text;
            label3.Text = "Verifying account...";
			if(logintextbox.Text != "" && passwordtextbox.Text != "")
			{
				string response = MClogin.generateSession(user, pass, 13);
				string[] split = response.Split(':');
                label3.Refresh();
				try{
					string sessionID = split[3];// Get Session ID
					string username = split[2];// Get username, in case user is on a migrated account.
					label3.ForeColor = System.Drawing.Color.White;
					label3.Text = "Checking and downloading necesary files.";
                    label3.Refresh();
					MinecraftDownloadUtils.CheckLibraries();
					label3.Text = "Login Sucessful.";
                    label3.Refresh();
					Thread.Sleep(3000);
					MClogin.startMinecraft(true, 256, 1024, username, sessionID, false);
				}
				catch (System.IndexOutOfRangeException)
				{
					label3.ForeColor = System.Drawing.Color.Red;
					if(response == "Bad login")
					{
						label3.Text = "Invalid username or password!";
					}
					else
					{
					label3.Text = response;
					}
				}
			}
			else{
				label3.ForeColor = System.Drawing.Color.Red;
				label3.Text = "Please input a valid username and password.";
			}
        }
	}
}

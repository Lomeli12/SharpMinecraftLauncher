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
		//MClogin loginclass = new MClogin();
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
			if(logintextbox.Text != "" && passwordtextbox.Text != "")
			{
				string response = MClogin.generateSession(user, pass, 13);
				string[] split = response.Split(':');
			try{
				
				string sessionID = split[3];
				WebClient downloadlib = new WebClient();
				string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft";
				string bin = path + "\\bin";
				string resources = path + "\\resources";
				string save = path + "\\saves";
				string stats = path + "\\stats";
				string texture = path + "\\texturepacks";
				string cache = path + "\\texturepacks-mp-cache";
				string minecraft = "minecraft.jar";
				string lwjgl = "lwjgl.jar";
				string jinput = "jinput.jar";
				string lwjgl_util = "lwjgl_util.jar";
				string natives = "\natives";
				string[] folders = new string[] { bin, resources, save, stats, texture, cache };
				foreach (string f in folders)
				{
					if(Directory.Exists(f))
					{
						
					}
					else
					{
						Directory.CreateDirectory(f);
					}
				}
				downloadlib.DownloadProgressChanged += client_DownloadProgressChanged;
				if(File.Exists(bin + @"\" + minecraft))
				{
				   	
				}
				else
				{
				   label3.Text = "Downloading " + minecraft;
				   downloadlib.DownloadFileAsync(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + minecraft, UriKind.RelativeOrAbsolute), (bin + @"\" + minecraft));
				}
				System.Threading.Thread.Sleep(12000);
				if(File.Exists(bin + @"\" + lwjgl))
				{
				   	
				}
				else
				{
				   label3.Text = "Downloading " + lwjgl;
				   downloadlib.DownloadFileAsync(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + lwjgl, UriKind.RelativeOrAbsolute), (bin + @"\" + lwjgl));
				}
				System.Threading.Thread.Sleep(7000);
				if(File.Exists(bin + @"\" + jinput))
				{
				   	
				}
				else
				{
				   label3.Text = "Downloading " + jinput;
				   downloadlib.DownloadFileAsync(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + jinput, UriKind.RelativeOrAbsolute), (bin + @"\" + jinput));
				}
				System.Threading.Thread.Sleep(7000);
				if(File.Exists(bin + @"\" + lwjgl_util))
				{
				   	
				}
				else
				{
				   label3.Text = "Downloading " + lwjgl_util;
				   downloadlib.DownloadFileAsync(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + lwjgl_util, UriKind.RelativeOrAbsolute), (bin + @"\" + lwjgl_util));
				}
				System.Threading.Thread.Sleep(1000);
				/*string[] jars = new string[] { minecraft, lwjgl, jinput, lwjgl_util };
				foreach (string j in jars)
				{
					if(File.Exists(bin + @"\" + j))
					{
						
					}
					else
					{
						downloadlib.DownloadProgressChanged += client_DownloadProgressChanged;
						label3.Text = "Downloading " + j;
						downloadlib.DownloadFileAsync(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + j, UriKind.RelativeOrAbsolute), (bin + @"\" + j));
					}
				}
				*/
				//MinecraftDownloadUtils.CheckLibraries();
				MessageBox.Show("Login Sucessful.");
				//MClogin.startMinecraft(true, 256, 1024, user, sessionID, false);
			}
			catch (System.IndexOutOfRangeException)
			{
				MessageBox.Show("Invalid username or password.");
			}
			}
			else{
				MessageBox.Show("Please input a valid username and password.");
			}
		}
		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            double downloaded = bytesIn / 1024;
            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            label3.Text = label3.Text + " " + downloaded.ToString();
        }
	}
}

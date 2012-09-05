using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;

namespace SharpMinecraftLauncher
{
	/// <summary>
	/// Description of MinecraftDownloadUtils.
	/// </summary>
	public class MinecraftDownloadUtils
	{

		public static void CheckLibraries()
		{
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
			string[] jars = new string[] { minecraft, lwjgl, jinput, lwjgl_util };
			foreach (string j in jars)
			{
				if(File.Exists(bin + @"\" + j))
				{
					
				}
				else
				{
					MinecraftDownloadUtils mc = new MinecraftDownloadUtils();
					downloadlib.DownloadProgressChanged += mc.client_DownloadProgressChanged;
					downloadlib.DownloadFileCompleted += mc.client_DownloadFileCompleted;
					downloadlib.DownloadFileAsync(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + j), (bin + @"\" + j));
					
				}
			}
		}
		void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			MessageBox.Show("1");
			Thread.Sleep(10000);
		}
		void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;
            double downloaded = bytesIn / 1024;
            double max = totalBytes / 1024;
            MainForm form1 = new MainForm();
            ((ProgressBar)form1.Controls[0]).Value = int.Parse(Math.Truncate(percentage).ToString());
        }


	}
}

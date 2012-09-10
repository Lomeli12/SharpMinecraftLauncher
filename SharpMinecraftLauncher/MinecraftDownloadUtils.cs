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
		public string download;
		public static void CheckLibraries()
		{
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
			string natives = "\\natives";
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
			if(File.Exists(bin + @"\" + minecraft))
			{
				
			}
			else
			{
				WebClient minedown = new WebClient();
				minedown.DownloadFile(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + minecraft), (bin + @"\" + minecraft));
			}
			if(File.Exists(bin + @"\" + lwjgl))
			{
				
			}
			else
			{
				WebClient lwdown = new WebClient();
				lwdown.DownloadFile(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + lwjgl), (bin + @"\" + lwjgl));
			}
			if(File.Exists(bin + @"\" + jinput))
			{
				
			}
			else
			{
				WebClient jindown = new WebClient();
				jindown.DownloadFile(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + jinput), (bin + @"\" + jinput));
			}
			if(File.Exists(bin + @"\" + lwjgl_util))
			{
				
			}
			else
			{
				WebClient lwjdown = new WebClient();
				lwjdown.DownloadFile(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + lwjgl_util), (bin + @"\" + lwjgl_util));
				
			}
			if(Directory.Exists(bin + natives)==true)
			{
				
			}
			else if(Directory.Exists(bin + natives)==false)
			{
				WebClient native = new WebClient();
				native.DownloadFile(new Uri("http://s3.amazonaws.com/MinecraftDownload/windows_natives.jar.lzma"), (bin + @"\" + "windows_natives.jar.lzma"));
				string thispath = Environment.CurrentDirectory.ToString();
				ProcessStartInfo p = new ProcessStartInfo();
				p.FileName = thispath + @"\7za.exe";
				p.Arguments = "x "+ (bin + @"\windows_natives.jar.lzma -o"+bin+"\\");
				p.WindowStyle = ProcessWindowStyle.Hidden;
				Process x = Process.Start(p);
				x.WaitForExit();
				File.Delete(bin + @"\" + "windows_natives.jar.lzma");
				Directory.CreateDirectory(bin + natives);
				ProcessStartInfo c = new ProcessStartInfo();
				c.FileName = thispath + @"\7za.exe";
				c.Arguments = "x " + (bin + "\\windows_natives.jar -o"+bin+natives);
				c.WindowStyle = ProcessWindowStyle.Hidden;
				Process b = Process.Start(c);
				b.WaitForExit();
				Directory.Delete(bin + natives + "\\META-INF");
				File.Delete(bin + natives + "\\windows_natives.jar");
			}
			/*string[] jars = new string[] { minecraft, lwjgl, jinput, lwjgl_util };
			foreach (string j in jars)
			{
				if(File.Exists(bin + @"\" + j))
				{
					
				}
				else
				{
					System.Threading.Tasks.Task.Factory.StartNew(() =>
					    {
						    WebClient downloadlib = new WebClient();
							downloadlib.DownloadFile(new Uri("http://s3.amazonaws.com/MinecraftDownload/" + j, UriKind.RelativeOrAbsolute), (bin + @"\" + j));
						});
				}
			}*/
			
		}

	}
}

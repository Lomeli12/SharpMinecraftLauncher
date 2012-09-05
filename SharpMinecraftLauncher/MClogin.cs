using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SharpMinecraftLauncher
{
	/// <summary>
	/// Description of MClogin.
	/// </summary>
	/* The following code was brought to you by the John_Dong
	 * Creator of the MCLoginLib Library
	 * The following code was added to make clients similar to
	 * the Technic-Lancher or the SpoutCraft Launcher
	 * By letting you run Minecraft from a special folder
	 * original library here: http://www.minecraftforum.net/topic/1445929-clauncher-library/
	*/
	public class MClogin
	{
		
		public static string generateSession(string username, string password, int clientVer)
		{
			return MClogin.httpGET(string.Concat(new object[]
			{
				"https://login.minecraft.net?user=",
				username,
				"&password=",
				password,
				"&version=",
				clientVer
			}));
		}
		
		public static string httpGET(string URI)
		{
			WebRequest webRequest = WebRequest.Create(URI);
			WebResponse response = webRequest.GetResponse();
			StreamReader streamReader = new StreamReader(response.GetResponseStream());
			return streamReader.ReadToEnd().Trim();
		}
		public static void startMinecraft(bool mode, int ramMin, int ramMax, string username, string sessionID, bool debug)
		{
			string text = Path.GetDirectoryName(Application.ExecutablePath) + "\\";
			string text2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
			Process process = new Process();
			if (debug)
			{
				process.StartInfo.FileName = "java";
			}
			else
			{
				process.StartInfo.FileName = "javaw";
			}
			if (mode)
			{
				process.StartInfo.Arguments = string.Concat(new object[]
				{
					"-Xms",
					ramMin,
					"M -Xmx",
					ramMax,
					"M -Djava.library.path=",
					text2,
					".minecraft/bin/natives -cp ",
					text2,
					".minecraft/bin/minecraft.jar;",
					text2,
					".minecraft/bin/jinput.jar;",
					text2,
					".minecraft/bin/lwjgl.jar;",
					text2,
					".minecraft/bin/lwjgl_util.jar net.minecraft.client.Minecraft ",
					username,
					" ",
					sessionID
				});
			}
			else
			{
				process.StartInfo.Arguments = string.Concat(new object[]
				{
					"-Xms",
					ramMin,
					"M -Xmx",
					ramMax,
					"M -Djava.library.path=",
					text2,
					".minecraft/bin/natives -cp ",
					text2,
					".minecraft/bin/minecraft.jar;",
					text2,
					".minecraft/bin/jinput.jar;",
					text2,
					".minecraft/bin/lwjgl.jar;",
					text2,
					".minecraft/bin/lwjgl_util.jar net.minecraft.client.Minecraft ",
					username
				});
			}
			process.Start();
		}
	}
}

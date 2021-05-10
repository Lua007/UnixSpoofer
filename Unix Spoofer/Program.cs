using System;
using System.Linq;
using Microsoft.Win32;

namespace Unix_Spoofer
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002088 File Offset: 0x00000288
		private static void Main()
		{
			Console.Title = "ZellixSpoofV3 discord.gg/tbEaZdrQ";
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.Clear();
			Console.WriteLine("\n\n            ███████╗███████╗██╗░░░░░██╗░░░░░██╗██╗░░██╗");
			Console.WriteLine("                ╚════██║██╔════╝██║░░░░░██║░░░░░██║╚██╗██╔╝");
			Console.WriteLine("                ░░███╔═╝█████╗░░██║░░░░░██║░░░░░██║░╚███╔╝░");
			Console.WriteLine("                ██╔══╝░░██╔══╝░░██║░░░░░██║░░░░░██║░██╔██╗░");
			Console.WriteLine("                ███████╗███████╗███████╗███████╗██║██╔╝╚██╗");
			Console.WriteLine("                ╚══════╝╚══════╝╚══════╝╚══════╝╚═╝╚═╝░░╚═╝");
			Console.WriteLine("\n                  ====================================");
			Console.WriteLine("                    [1] Check HWID        [2] Spoof HWID");
			Console.WriteLine("                    ====================================");
			Console.Write("\n>");
			string text = Console.ReadLine();
			string text2 = text;
			string a = text2;
			if (!(a == "1"))
			{
				if (a == "2")
				{
					Program.SpoofHWID();
				}
			}
			else
			{
				Program.CheckHWID();
			}
			Console.ReadKey();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002148 File Offset: 0x00000348
		public static void CheckHWID()
		{
			try
			{
				Console.Clear();
				string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
				string str = (string)Registry.GetValue(keyName, "GUID", "default");
				Console.WriteLine("[Unix] Current HWID: " + str);
				Console.ReadKey();
				Program.Main();
			}
			catch (Exception)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("[Unix] There was an error while getting your HWID");
				Console.ReadKey();
				Program.Main();
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000021C8 File Offset: 0x000003C8
		public static void SpoofHWID()
		{
			try
			{
				Console.Clear();
				string keyName = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
				string str = (string)Registry.GetValue(keyName, "HwProfileGuid", "default");
				string text = string.Concat(new string[]
				{
					"{Unix-",
					Program.GenID(5),
					"-",
					Program.GenID(5),
					"-",
					Program.GenID(4),
					"-",
					Program.GenID(9),
					"}"
				});
				Registry.SetValue(keyName, "GUID", text);
				Registry.SetValue(keyName, "HwProfileGuid", text);
				Console.WriteLine("[Unix] Successfully Changed Your HWID!");
				Console.WriteLine("\n[Unix] Old HWID: " + str);
				Console.WriteLine("\n[Unix] New HWID: " + text);
				Console.ReadKey();
				Program.Main();
			}
			catch (Exception)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("[Unix] There was an error while changing your HWID, Try running this tool as an administrator.");
				Console.ReadKey();
				Program.Main();
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022D4 File Offset: 0x000004D4
		public static string GenID(int length)
		{
			string element = "123456789";
			return new string((from s in Enumerable.Repeat<string>(element, length)
			select s[Program.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x04000001 RID: 1
		private static Random random = new Random();
	}
}

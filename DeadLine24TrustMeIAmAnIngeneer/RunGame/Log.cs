
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL24
{
	public class Log
	{
		public static void Add(string[] message)
		{
			foreach (var s in message)
			{
				Console.WriteLine(s);
			}
		}

		public static void AddFromServer(string[] message)
		{
			foreach (var s in message)
			{
				Console.WriteLine($"server > {s}");
			}
		}

		public static void AddFromClient(string message)
		{
			Console.WriteLine($"client > {message}");
		}
	}
}

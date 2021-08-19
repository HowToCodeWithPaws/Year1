using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryFiles2
{
	class Program
	{
		static void Main(string[] args)
		{
			const string path = "../../../intNum.txt";

			if (!File.Exists(path))
			{
				return;
			}

			string text = File.ReadAllText(path);
			string[] allNumbers = text.Split(' ');

			Console.WriteLine(text + Environment.NewLine);

			foreach (string num in allNumbers)
			{
				Console.WriteLine(num);
			}

			byte[] bytes = File.ReadAllBytes(path);
			foreach (byte bytee in bytes)
			{

			}
		}
	}
}
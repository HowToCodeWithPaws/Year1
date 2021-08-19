using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class Program
	{
		public static string GenerateName()
		{
			string name = "";
			int len = ran.Next(2, 10);
			for (int i = 0; i < len; i++)
			{
				name += (char)ran.Next(65, 91);
			}

			return name;
		}

		public static Random ran = new Random();
		static void Main(string[] args)
		{
			VideoFile file = new VideoFile(GenerateName(), ran.Next(60, 361), ran.Next(100, 1001));

			VideoFile[] files = new VideoFile[ran.Next(5,16)];
			for (int i = 0; i < files.Length; i++)
			{
				files[i] = new VideoFile(GenerateName(), ran.Next(60, 361), ran.Next(100, 1001));
			}

			Console.WriteLine($"Отдельный файл\n{file.ToString()}\nразмер {file.Size}");

			for (int i = 0; i < files.Length; i++)
			{
				if (files[i].Size>file.Size)
				{
					Console.WriteLine($"\nФайл \n{files[i].ToString()} \nс номером {i}\nи размером больше размера отдельного файла\n{files[i].Size} > {file.Size} ");
				}
			}
		}
	}
}

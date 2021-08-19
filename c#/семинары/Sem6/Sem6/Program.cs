using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sem6
{
	class Program
	{
		static void DirectoryOverview(string path, uint k, List<string> deleted)
		{
			var directories = Directory.GetDirectories(path);

			foreach (string item in directories)
			{
				var directory = item;

				var directoryInfo = new DirectoryInfo(directory);

				Console.WriteLine($"{directory}\n" + $"attributes: {directoryInfo.Attributes} "
				+ $"creation time: {directoryInfo.CreationTime} " + $"last update: {directoryInfo.LastWriteTime}\n");

				if (k > 0)
				{
					DirectoryOverview(directory, k - 1, deleted);
				}

				if (directoryInfo.GetFiles().Length + directoryInfo.GetDirectories().Length == 0)
				{
					deleted.Add(directoryInfo.FullName);
					directoryInfo.Delete();
					return;
				}
			}
		}

		public static uint Read()
		{
			uint input;

			do
			{
				Console.WriteLine("Введите глубину обхода.");
			} while (!uint.TryParse(Console.ReadLine(), out input) || input == 0);

			return input;
		}

		static void Main(string[] args)
		{

			List<string> deleted = new List<string>();
			try
			{
				Console.Write("Введите адрес ");

				string path = Console.ReadLine();

				uint k = Read();

				DirectoryOverview(path, k, deleted);
			}
			catch (IOException ex)
			{
				Console.WriteLine($"Произошла ошибка чтения:{ex.Message}");
			}
			catch (System.Security.SecurityException ex)
			{
				Console.WriteLine($"Произошла ошибка безопасности: {ex.Message}");
			}
			finally
			{
				Console.WriteLine($"Удаленные директории: " + $"{String.Join(Environment.NewLine, deleted.ToArray())}");
			}
		}
	}
}

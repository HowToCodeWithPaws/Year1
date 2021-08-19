using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using EKRLib;

namespace ConsoleApp2
{
	class Program
	{
		public static Collection<Box> Deserialize()
		{ /// Блок try catch для обработки исключений, которые
		  /// могут возникнуть при работе с файлами.

			Collection<Box> boxes = null;
			try
			{

				/// Реализация чтения с использованием файловых потоков.
				/// Альтернативно можно было руками создавать новый поток и
				/// осуществлять Flush и Dispose, но так удобнее.
				using (FileStream fs = new FileStream("../../../gettingReady/bin/Debug/boxes.json",
					FileMode.Open, FileAccess.Read))
				{
					using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
					{
						boxes = JsonConvert.DeserializeObject<Collection<Box>>(sr.ReadToEnd());
						Console.WriteLine("deserialization complete\n");
					}
				}

				foreach (Box box in boxes)
				{
					Console.WriteLine(box.ToString());
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не существует. Исправьте ошибку и попробуйте снова.");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода-вывода. Исправьте ошибку и попробуйте снова.");
			}
			catch (System.Security.SecurityException)
			{
				Console.WriteLine("Ошибка безопасности при работе с файлом. " +
					"Исправьте ошибку и попробуйте снова.");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("У вас нет разрешения на чтение файла. " +
					"Исправьте ошибку и попробуйте снова.");
			}
			catch (ItemsException ex)
			{
				Console.WriteLine("Неверные параметры объекта.\n" + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("При работе с файлом произошла ошибка. " +
					"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
			}

			return boxes;
		}
		/// <summary>
		/// 1) Сформировать и вывести на экран коллекцию, содержащую все объекты
		/// с максимальным измерением большим чем 3, отсортированные в порядке убывания значений их наибольших из измерений. 

		public static void FirstLinq(Collection<Box> boxes)
		{
			Console.WriteLine("\nboxes with msx dimension > 3:");

			var maxDim = from box in boxes
						 where box.GetLongestSideSize() > 3
						 orderby box.GetLongestSideSize() descending
						 select box;

			foreach (Box box in maxDim)
			{
				Console.WriteLine(box.ToString());
			}
		}
		///2) Сформировать и вывести на экран сложную коллекцию, состоящую из M других,
		///формирующихся по принципу равенства масс коробок, где М – количество уникальных масс коробок.
		///Это означает, что если всего существует 5 различных значений масс коробок, 
		///то будет одновременно сформировано 5 коллекций, каждая из которых будет содержать коробки только одной массы.

		public static void SecondLinq(Collection<Box> boxes)
		{
			Console.WriteLine("\nboxes with different weights:");

			var weights = from box in boxes
						  group box by box.Weight;

			foreach (var group in weights)
			{

				//foreach (Box box in group)
				//{
				//	Console.WriteLine(box.ToString());
				//}
				Console.WriteLine(string.Join(" | ", group));
			}
		}

		///3) Сформировать и вывести на экран коллекцию, содержащую только имеющие максимальную массу коробки, и их количество.
		/// </summary>
		public static void ThirdLinq(Collection<Box> boxes)
		{
			var heavyboxes = from box in boxes
							 where (double)box == boxes.Max(b => (double)b)
							 select box;

			Console.WriteLine($"\n{heavyboxes.Count()} boxes with max weight:");
			Console.WriteLine(string.Join(" | ", heavyboxes));

		}

		static void Main(string[] args)
		{
			/// С помощью цикла do while с условием нажатия клавиши Enter
			/// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			/// повторного решения задачи по желанию пользователя.
			do
			{
				try {
					Collection<Box> boxes = Deserialize();

					FirstLinq(boxes);

					SecondLinq(boxes);

					ThirdLinq(boxes);
				}
				catch (Exception ex)
				{
					Console.WriteLine("При произошла ошибка. " +
						"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
				}
				

				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}
	}
}

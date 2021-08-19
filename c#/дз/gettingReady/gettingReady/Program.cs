using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EKRLib;
using Newtonsoft.Json;

namespace gettingReady
{
	class Program
	{

		/// <summary>
		/// Метод выводит сообщение с переданной информацией и осуществляет
		/// считывание переменной типа int с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг, также метод принимает
		/// на вход границы значений считываемого числа, соответствие которым
		/// также проверяется внутри условия do while, дефолтно они задаются
		/// как int Min и MaxValue.
		/// </summary>
		/// <param name="message"> Входной параметр выводимого сообщения. </param>
		/// <param name="minvalue"> Входной параметр нижней границы значения 
		/// числа. </param>
		/// <param name="maxvalue"> Входной параметр верхней границы значения
		/// числа. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу.</returns>
		public static int Read(string message, int minvalue = int.MinValue,
			int maxvalue = int.MaxValue)
		{
			int input;

			do
			{
				Console.Write(message);
			} while (!int.TryParse(Console.ReadLine(), out input)
		   || input < minvalue || input > maxvalue);

			return input;
		}


		/// <summary>
		/// Метод, генерирующий случайное вещественное число в требуемом
		/// интервале (левая граница включается) с использованием
		/// экземпляра класса Random.
		/// </summary>
		/// <param name="minvalue"> Параметр левой границы интервала. </param>
		/// <param name="maxvalue"> Параметр правой границы интервала. </param>
		/// <returns> Возвращает сгенерированное число. </returns>
		public static double RandomDouble(double minvalue, double maxvalue)
		{
			return minvalue + random.NextDouble() * (maxvalue - minvalue);
		}

		public static Random random = new Random();

		public static void CreateBoxes(int N, Collection<Box>  boxes) {
			for (int i = 0; i < N; i++)
			{
				try
				{
					boxes.Add(new Box(RandomDouble(-3, 10), RandomDouble(-3, 10), RandomDouble(-3, 10), RandomDouble(-3, 10)));
				}
				catch (ItemsException e)
				{
					Console.WriteLine(e.Message);
					i--;
				}
			}
		}

		static void Main(string[] args)
		{
			/// С помощью цикла do while с условием нажатия клавиши Enter
			/// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			/// повторного решения задачи по желанию пользователя.
			do
			{
				Collection<Box> boxes = new Collection<Box>();

				int N = Read("Write the number of boxes you want (an integer in interval [1, 100]): ", 1, 100);

				CreateBoxes(N, boxes);

				foreach (Box box in boxes)
				{
					Console.WriteLine(box.ToString());
				}

				/// Блок try catch для обработки исключений, которые
				/// могут возникнуть при работе с файлами.
				try
				{

					/// Реализация записи с использованием файловых потоков.
					/// Альтернативно можно было руками создавать новый поток и
					/// осуществлять Flush и Dispose, но так удобнее.
					using (FileStream fs = new FileStream("boxes.json", FileMode.Create, FileAccess.Write))
					{
						using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
						{
							sw.Write(JsonConvert.SerializeObject(boxes));
							//JsonSerializer serializer = new JsonSerializer();
							//serializer.Serialize(sw, boxes);
							Console.WriteLine("serialization finished");
						}
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
				catch (Exception ex)
				{
					Console.WriteLine("При работе с файлом произошла ошибка. " +
						"Исправьте ошибку и попробуйте снова.\n" + ex.Message);
				}


				Console.WriteLine("\nНажмите Enter, чтобы повторить решение," +
					"для выхода нажмие любую другую клавишу.");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}
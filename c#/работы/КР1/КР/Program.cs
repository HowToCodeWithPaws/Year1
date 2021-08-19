using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BirdsLib;
using static BirdsLib.Utilities;

/// <summary>
/// Зубарева Наталия БПИ199
/// Вариант 3
/// 14.12.19
/// </summary>

namespace КР
{
	class Program
	{
		/// <summary>
		/// Метод генерирует имя определенной длины, начинающееся с заглавной буквы.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static string GenerateName(int length)
		{
			string name = ((char)random.Next('A', 'Z')).ToString();

			for (int i = 0; i < length - 1; i++)
			{
				name += (char)random.Next('a', 'z');
			}

			return name;
		}

		/// <summary>
		/// Метод кладет в массив по индексу объект типа Воробей со 
		/// сгенерированными параметрами, вызывается до тех пор, пока не 
		/// перестает возникать эксепшн: когда все параметры верны.
		/// </summary>
		/// <param name="birds"> Массив птиц. </param>
		/// <param name="i"> Индекс. </param>
		public static void GenerateSparrow(Bird[] birds, int i)
		{
			try
			{
				birds[i] = new Sparrow(GenerateName(random.Next(1, 11)),
					random.Next(-5, 31));
				return;
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
				GenerateSparrow(birds, i);
			}
		}

		/// <summary>
		/// Метод кладет в массив по индексу объект типа Орел со 
		/// сгенерированными параметрами, вызывается до тех пор, пока не 
		/// перестает возникать эксепшн: когда все параметры верны.
		/// </summary>
		/// <param name="birds"> Массив птиц. </param>
		/// <param name="i"> Индекс. </param>
		public static void GenerateEagle(Bird[] birds, int i)
		{
			try
			{
				birds[i] = new Eagle(GenerateName(random.Next(1, 11)),
					random.Next(-5, 51));

				return;
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
				GenerateEagle(birds, i);
			}
		}

		/// <summary>
		/// В методе мейн вызываются все остальные методы и осуществляется 
		/// работа программы с возможностью повторения.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Переменные для массива птиц, расстояния которое пролетели оба вида птиц,
				// информации о птицах обоих видов.
				Bird[] birds = new Bird[10];
				int fliedEagles = 0, fliedSparrows = 0;
				string eaglesInfo = string.Empty, sparrowsInfo = string.Empty;

				// Заполнение массива - равновероятно вызывается метод создания
				// орла или воробья.
				for (int i = 0; i < 10; i++)
				{
					if (random.Next(0, 2) % 2 == 0)
					{
						GenerateSparrow(birds, i);
					}
					else
					{
						GenerateEagle(birds, i);
					}
				}

				// В цикле фор ич для каждой птицы вызывается метод мув, записывается информация 
				// о пролете всех птиц обоих видов в соответствующие переменные, запоминается 
				// информация обо всех птицах обоих типов для последующей записи в файл.
				// Альтернативно можно было не делать переменные строки для информации, сделать
				// массивы строк, записывать через write all lines.
				foreach (Bird bird in birds)
				{
					if (bird is Sparrow)
					{
						fliedSparrows += bird.Move();
						sparrowsInfo += bird.ToString() + Environment.NewLine;
					}

					if (bird is Eagle)
					{
						fliedEagles += bird.Move();
						eaglesInfo += bird.ToString() + Environment.NewLine;
					}
				}

				// Вывод информации о пролете всех птиц обоих видов.
				Console.WriteLine(Environment.NewLine + $"Sparrows flied {fliedSparrows} km"
					+ Environment.NewLine + $"Eagles flied {fliedEagles } km");

				/// Блок try catch обрабатывает возможные исключения, 
				/// возникающие при работе с файлами.
				/// Альтернативное решение: можно было делать запись через StreamWriter.
				try
				{
					// Запись в файлы.
					File.WriteAllText("Sparrows.txt", sparrowsInfo,
						Encoding.Unicode);
					File.WriteAllText("Eagles.txt", eaglesInfo,
						Encoding.Unicode);
				}
				catch (FileNotFoundException e)
				{
					Console.WriteLine("Файл не существует" + Environment.NewLine + e);
				}
				catch (IOException e)
				{
					Console.WriteLine("Ошибка ввода/вывода" + Environment.NewLine + e);
				}
				catch (UnauthorizedAccessException e)
				{
					Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла"
						+ Environment.NewLine + e);
				}
				catch (System.Security.SecurityException e)
				{
					Console.WriteLine("Ошибка безопасности" + Environment.NewLine + e);
				}
				finally
				{
					Console.WriteLine("Работа с файлами завершена");
				}


				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой " +
					"другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

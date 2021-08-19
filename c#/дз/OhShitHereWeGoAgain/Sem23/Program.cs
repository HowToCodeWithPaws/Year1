using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using FantasyLib;
using System.IO;

namespace Sem23
{
	class Program
	{
		public static Random random = new Random();
		public static List<IHero> heroes;

		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				heroes = new List<IHero>();

				for (int i = 0; i < 40; i++)
				{
					double damage;
					string name;

					CreateHero(out name, out damage);

					try
					{
						if (random.Next(0, 2) % 2 == 0)
						{
							Warrior warrior = new Warrior(name, damage);
							warrior.DateOfCreation = DateTime.Now;
							heroes.Add(warrior);
							Console.WriteLine(warrior.ToString());
						}
						else
						{
							Mage mage = new Mage(name, damage);
							mage.DateOfCreation = DateTime.Now;
							heroes.Add(mage);
							Console.WriteLine(mage.ToString());
						}
					}
					catch (HeroException e)
					{
						Console.WriteLine(e.Message);
					}

					Thread.Sleep(2000);

				}

				Console.WriteLine("\n\nCreation finished, you may rest for a day\n\n");

				FirstSorting();

				SecondSorting();

				ThirdSorting();

				ForthSorting();

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}

		public static void CreateHero(out string name, out double damage)
		{
			damage = random.Next(-5, 15) + random.NextDouble();
			name = "";

			name += (char)random.Next('A', 'Z' + 1);

			for (int i = 0; i < random.Next(1, 13); i++)
			{
				name += (char)random.Next('a', 'z' + 1);
			}
		}

		public static void FirstSorting()
		{

			Console.WriteLine("\nBeginning the first sorting");

			heroes.Sort();

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				using (StreamWriter writer =
				new StreamWriter(new FileStream("2HeroesByIComparable.txt", FileMode.Create),
				Encoding.UTF8))
				{
					foreach (IHero hero in heroes)
					{
						writer.WriteLine(hero.ToString());
						writer.Flush();
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не существует");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода/вывода");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
			}
			catch (System.Security.SecurityException)
			{
				Console.WriteLine("Ошибка безопасности");
			}

			Console.WriteLine("First sorting finished\n\n");
		}

		///3) Отсортировать список по лексикографическому возрастанию имен героев, 
		///воспользовавшись лямбда-выражением для указания порядка сортировки.
		///Вывести информацию из отсортированного списка в тестовый файл "3HeroesByName.txt" 
		///с использованием потоков(кодировка UTF-8, расположение: папка с исполняемым файлом проекта).
		///Информация о каждом герое – с новой строки.
		public static void SecondSorting()
		{
			Console.WriteLine("\nBeginning the second sorting");

			heroes.Sort((a, b) => a.Name.CompareTo(b.Name));

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				using (StreamWriter writer =
				new StreamWriter(new FileStream("3HeroesByName.txt", FileMode.Create),
				Encoding.UTF8))
				{
					foreach (IHero hero in heroes)
					{
						writer.WriteLine(hero.ToString());
						writer.Flush();
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не существует");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода/вывода");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
			}
			catch (System.Security.SecurityException)
			{
				Console.WriteLine("Ошибка безопасности");
			}

			Console.WriteLine("Second sorting finished\n\n");
		}

		///4) Отсортировать список так(использовать анонимный метод для задания порядка сортировки),
		///чтобы сначала была группа объектов Warrior, а потом группа объектов Mage.При этом внутри
		///одной группы объекты отсортировать согласно реализации IComparable<IHero>.
		///Вывести информацию из отсортированного списка в тестовый файл "4HeroesByTypeAndIcomparable.txt"
		///с использованием потоков (кодировка UTF-8, расположение: папка с исполняемым файлом проекта).
		///Информация о каждом питомце – с новой строки.
		public static void ThirdSorting()
		{
			Console.WriteLine("\nBeginning the third sorting");

			heroes.Sort(delegate (IHero a, IHero b)
			{
				if (a is Mage && b is Warrior)
				{
					return 1;
				}
				if (a is Warrior && b is Mage)
				{
					return -1;
				}

				return a.CompareTo(b);
			});

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				using (StreamWriter writer =
				new StreamWriter(new FileStream("4HeroesByTypeAndIcomparable.txt", FileMode.Create),
				Encoding.UTF8))
				{
					foreach (IHero hero in heroes)
					{
						writer.WriteLine(hero.ToString());
						writer.Flush();
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не существует");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода/вывода");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
			}
			catch (System.Security.SecurityException)
			{
				Console.WriteLine("Ошибка безопасности");
			}

			Console.WriteLine("Third sorting finished\n\n");
		}

		///5) Отсортировать список так, чтобы в начале шли герои, секунда времени создания
		///которых делится без остатка на 3, а затем все остальные.При этом внутри групп отсортировать
		///в соответствии с реализацией Icomparable<IHero>.Вывести информацию из отсортированного
		///списка в тестовый файл "5HeroesBySecondsAndIcomparable.txt" с использованием потоков
		///(кодировка UTF-8, расположение: папка с исполняемым файлом проекта). 
		///Информация о каждом питомце – с новой строки.
		/// </summary>
		public static void ForthSorting()
		{
			Console.WriteLine("\nBeginning the forth sorting");

			heroes.Sort(delegate (IHero a, IHero b)
			{
				if (a.DateOfCreation.Second%3==0 && b.DateOfCreation.Second % 3 != 0)
				{
					return -1;
				}
				if (b.DateOfCreation.Second % 3 == 0 && a.DateOfCreation.Second % 3 != 0)
				{
					return 1;
				}

				return a.CompareTo(b);
			});

			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				using (StreamWriter writer =
				new StreamWriter(new FileStream("5HeroesBySecondsAndIcomparable.txt", FileMode.Create),
				Encoding.UTF8))
				{
					foreach (IHero hero in heroes)
					{
						writer.WriteLine(hero.ToString());
						writer.Flush();
					}
				}
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("Файл не существует");
			}
			catch (IOException)
			{
				Console.WriteLine("Ошибка ввода/вывода");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
			}
			catch (System.Security.SecurityException)
			{
				Console.WriteLine("Ошибка безопасности");
			}

			Console.WriteLine("Forth sorting finished\n\n");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetLib;
using System.IO;

/// <summary>
/// Зубарева Наталия
/// бпи199
/// Вариант 
/// 26.03.20
/// </summary>

namespace ConsoleApp
{
	class Program
	{
		// Статические поля для экземпляра 
		// рандомайзера и списка питомцев.
		public static Random random = new Random();
		public static List<IPet> pets;

		/// <summary>
		/// Точка входа, в этом методе происходит
		/// блок для повтора решения и вызов методов
		/// создания списка и различных сортировок 
		/// с последующей записью в файл.
		/// </summary>
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется 
			// возможность повторного решения задачи по желанию пользователя.
			do
			{
				// Вызов метода заполнения списка.
				FillTheList();

				// Вызов метода первой сортировки.
				Sorting1();

				// Вызов метода второй сортировки.
				Sorting2();

				// Вызов метода третьей сортировки.
				Sorting3();

				Console.WriteLine("\nДля повторного решения нажмите Enter," +
					" для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}

		/// <summary>
		/// Метод для заполнения списка питомцев ссылками
		/// на животных.
		/// </summary>
		public static void FillTheList()
		{
			// Инициализация списка.
			pets = new List<IPet>();

			Console.WriteLine("\n\nНачинаем создавать зоопарк...\n\n");

			// Заполнение списка, 40 попыток, чтобы создать
			// 40 кошек (возможно(желательно)).
			for (int i = 0; i < 40; i++)
			{
				// Переменные для массы и имени.
				double mass;
				string name;

				// Вызов метода, генерирующего имена и массы для животных.
				CreatePet(out name, out mass);

				// Блок для поимки исключений при создании животных,
				// текст исключений выводится в консоль.
				try
				{
					// Равновероятно производятся попытки создать 
					// и добавить в список кошку либо песеля.
					if (random.Next(0, 2) % 2 == 0)
					{
						Cat cat = new Cat(name, mass);
						pets.Add(cat);
						Console.WriteLine(cat.ToString());
					}
					else
					{
						Dog dog = new Dog(name, mass);
						pets.Add(dog);
						Console.WriteLine(dog.ToString());
					}
				}
				catch (PetException e)
				{
					Console.WriteLine(e.Message);
				}
			}

			Console.WriteLine("\n\nСоздание зоопарка закончено!\n\n");
		}

		/// <summary>
		/// Метод, генерирующий параметры для животных:
		/// имя по спецификации но длиной от 2 до 13 символов,
		/// массу от -5 до 15.
		/// Альтернативное решение: имя можно было создавать с помощью regex.
		/// </summary>
		/// <param name="name"> Выводит строку с именем. </param>
		/// <param name="mass"> Выводит число - массу. </param>
		public static void CreatePet(out string name, out double mass)
		{
			// Переменные для имени и массы.
			mass = random.Next(-5, 15) + random.NextDouble();
			name = "";

			int length = random.Next(1, 13);

			// Добавление символов к имени по рандомной длине.
			name += (char)random.Next('A', 'Z' + 1);

			for (int i = 0; i < length; i++)
			{
				name += (char)random.Next('a', 'z' + 1);
			}
		}

		/// <summary>
		/// Метод, сортирующий список по дефолтному определению
		/// сравнения в классе Pet.
		/// Далее происходит запись отсортированного списка в файл.
		/// </summary>
		public static void Sorting1()
		{
			Console.WriteLine("\nНачинаем первую сортировочку...");

			// Вызываем сортировку стандартным методом списков.
			pets.Sort();

			// Вызов метода для записи в нужный файл.
			Write("2PetsByIComparable.txt");

			Console.WriteLine("...первая сортировочка закончена!\n\n");
		}

		/// <summary>
		/// Метод, сортирующий список с помощью лямбда-выражения,
		/// задающего лексикографическую сортировку.
		/// Далее происходит запись отсортированного списка в файл.
		/// </summary>
		public static void Sorting2()
		{
			Console.WriteLine("\nНачинаем вторую сортировочку...");

			// Вызываем перегрузку сортировки списка с лямбдой.
			pets.Sort((a, b) => a.Name.CompareTo(b.Name));

			// Вызов метода записи в файл с нужным адресом.
			Write("3PetsByName.txt");

			Console.WriteLine("...вторая сортировочка закончена!\n\n");
		}

		/// <summary>
		/// Метод, сортирующий список по категориям кошки\собаки
		/// и внутри категорий по стандартному сравнению питомцев
		/// с помощью анонимного метода.
		/// Далее происходит запись отсортированного списка в файл.
		/// </summary>
		public static void Sorting3()
		{
			Console.WriteLine("\nНачинаем третью сортировочку...");

			// Вызов сортировки с перегрузкой для анонимного 
			// метода сравнения.
			pets.Sort(delegate (IPet a, IPet b)
			{
				if (a is Dog && b is Cat)
				{
					return 1;
				}
				if (a is Cat && b is Dog)
				{
					return -1;
				}

				return a.CompareTo(b);
			});

			// Вызов метода записи в файл с нужным адресом.
			Write("4PetsByTypeAndMass.txt");

			Console.WriteLine("...третья сортировочка закончена!\n\n");
		}

		/// <summary>
		/// Метод для записи списка в файл 		
		/// /// с использованием потоков и кодировкой utf-16.
		/// Здесь потоки открываются через using, альтернативно
		/// можно было открывать и закрывать их руками через Open и Dispose.
		/// </summary>
		/// <param name="path"> Принимает на вход адрес, по 
		/// которому нужно записать файл. </param>
		public static void Write(string path)
		{
			/// Блок try catch обрабатывает возможные исключения,
			/// возникающие при работе с файлами.
			try
			{
				// Открываем поток и производим запись.
				using (StreamWriter writer =
				new StreamWriter(new FileStream(path, FileMode.Create),
				Encoding.Unicode))
				{
					foreach (IPet pet in pets)
					{
						writer.WriteLine(pet.ToString());
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
			catch (Exception e)
			{
				Console.WriteLine("Что-то пошло не так!"+e.Message);
			}
		}
	}
}

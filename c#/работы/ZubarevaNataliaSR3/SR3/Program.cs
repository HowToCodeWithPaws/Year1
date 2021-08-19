using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR3
{
	class Program
	{
		/// <summary>
		/// Генерация случайных чисел.
		/// </summary>
		public static Random random = new Random();

		/// <summary>
		/// В методе объявляется и инициализируется массив 
		/// элементов класса Животное, проводится вывод информации
		/// и изменение голода самого голодного животного.
		/// </summary>
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Объявление массива животных.
				Animal[] animals = new Animal[5];

				// Инициализация массива животных.
				for (int i = 0; i < 5; i++)
				{
					animals[i] = new Animal(random.NextDouble() + random.Next(0, 10));
				}

				// Вывод информации о животных через foreach.
				Console.WriteLine("Information about animals:");

				foreach (Animal animal in animals)
				{
					Console.WriteLine("\n" + animal.ToString());
				}

				// Поиск животного с максимальным голодом в цикле.
				// Альтернативное решение: можно было использовать
				// метод класса Array.
				double maxHunger = double.MinValue;
				int rem = 0;

				for (int i = 0; i < 5; i++)
				{
					if (animals[i].Hunger > maxHunger)
					{
						maxHunger = animals[i].Hunger;
						rem = i;
					}
				}

				// Вывод информации о самом голодном животном.
				Console.WriteLine($"\nThe hungriest animal is:" +
					$"\n{animals[rem].ToString()}");

				// Изменение голода животного.
				animals[rem].Hunger -= 3;

				// Вывод информации о самом голодном животном после изменения.
				Console.WriteLine($"\nThe hungriest animal is now less " +
					$"hungry:\n{animals[rem].ToString()}");

				Console.WriteLine("\nДля повторного решения нажмите Enter, " +
					"для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

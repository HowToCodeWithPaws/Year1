using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

/// <summary>
/// Зубарева Наталия БПИ199
/// вариант 1
/// </summary>

namespace SR
{
	class Program
	{
		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Заполнение экземпляра делегата методами класса.
				Burger.BurgerAction action = Burger.AddBunToBurger;
				action += Burger.AddPattyToBurger;
				action += Burger.AddBunToBurger;

				// Создание объекта класса.
				Burger hamburger = new Burger("Hamburger");

				// Вызов делегата.
				action(hamburger);

				// Вывод информации.
				Console.WriteLine(hamburger.ToString());
				
				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

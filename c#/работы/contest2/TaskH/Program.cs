using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Проверьте, является ли число простым. Для этого напишите метод: 
/// bool IsPrime(int number)
/// Вводится одно число большее 1 и меньшее 2 ⋅ 109.
/// Необходимо вывести строку prime, если число простое, или composite, если число составное.
/// В случае, если входные данные не соответствуют условию, выведите строку wrong и сразу же завершите выполнение программы

namespace TaskH
{
	class Program
	{
		/// <summary>
		/// Метод проверяет, является ли введенное число number простым с помощью условного оператора if внутри цикла for для перебора чисел i от 2 до корня 
		/// из number, сравнивая остаток от деления number на i с нулем, если number - составное, метод возвращает булевое false, если число простое - true.
		/// </summary>
		/// <param name="number"> Переменная для вводимого числа, для которого проверяется делимость на другие числа. </param>
		/// <returns> Метод возвращает булевое true, если число простое и false, если число составное. </returns>

		static bool IsPrime(int number)
		{
			for (int i = 2; i <= Math.Sqrt(number); i++)
			{
				if (number % i == 0) return false;
			}
			return true;
		}

		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную целочисленного типа
		/// с помощью метода TryParse, возвращает значение переменной и переменную булевого типа, показывающую,
		/// удалось ли преобразование (корректны ли входные данные).
		/// </summary>
		/// <param name="readIn"> Переменная булевого типа, отражающая корректность вводных данных для переменной. </param>
		/// <returns> Метод возвращает считываемую переменную input. </returns>

		static int Read(out bool readIn)
		{
			int input;
			readIn = int.TryParse(Console.ReadLine(), out input);
			return input;
		}

		/// <summary>
		/// 
		/// </summary>

		static void Main(string[] args)
		{
			// Переменная для вводимого числа - целого типа.

			int number;

			// Переменная булевого типа для проверки корректности вводимых данных.

			bool readNumber;

			// Вызов метода считывания числа.

			number = Read(out readNumber);

			// Проверка корректности входных данных: типа и размера числа (больше 1 и меньше 2*10^9).

			if (readNumber && number > 1 && number < 2000000000)
			{
				// Вызов метода проверки, составное ли число, внутри условного оператора if. Если число простое, метод возвращает 1, выводится строка prime,
				// иначе - composite.

				if (IsPrime(number))
				{
					Console.WriteLine("prime");
				}
				else
					Console.WriteLine("composite");
			}
			else
				// Вывод строки wrong и завершение работы программы.

				Console.WriteLine("wrong");
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Вычислить значение выражения 2^𝑁+2^𝑀, 𝑁, 𝑀 – целые неотрицательные числа вводятся пользователем с клавиатуры.
//Используйте битовые операции для организации «быстрого умножения». Помните о возможности переполнения.


namespace Task4
{
	class Program
	{
		static ulong Function(uint power1, uint power2)
		{
			return (ulong)((2 << (int)(power1 - 1)) + (2 << (int)(power2 - 1)));
		}

		public static uint Read(string name)
		{
			uint In;

			do
			{
				Console.Write($"Введите {name}  ");
			} while (!uint.TryParse(Console.ReadLine(), out In));
			return In;
		}

		static void Main(string[] args)
		{
			do
			{
				uint powerN, powerM;

				powerN = Read("N");
				powerM = Read("M");

				Console.WriteLine(Function(powerN, powerM));

				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

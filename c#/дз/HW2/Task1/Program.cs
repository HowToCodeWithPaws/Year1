using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ввести значение x и вывести значение полинома: F(x) = 12x4 + 9x3 - 3x2 + 2x – 4.
//Не применять возведение в степень. Использовать минимальное количество операций умножения.

namespace Task1
{
	class Program
	{
		public static double ReadDouble()
		{
			double X;

			do
			{
				Console.Write("Введите X = ");
			} while (!double.TryParse(Console.ReadLine(), out X));

			return X;

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число
		static double Count(double In)
		{
			return (In * (In * (In * (In + In + In + In + In + In + In + In + In + In + In + In + 9) - 3) + 2) - 4);
		}//метод вычисляет значение многочлена от входного значения In. использовано минимальное число знаков умножения, это можно было также реализовать используя знаки деления (12*In = 12\(1\In) )
		static void Main(string[] args)//переменной Х присваивается прочитанное в методе ReadDouble значение, выводится значение Х, циклом с постусловием предусмотрено повторное решение
		{
			do
			{
				double X = ReadDouble();

				Console.WriteLine($"Значение функции от введенного Х равно {Count(X):F3}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}

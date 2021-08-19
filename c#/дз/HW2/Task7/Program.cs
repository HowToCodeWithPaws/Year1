using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Написать программу с использованием двух методов. Первый метод возвращает 
//дробную и целую часть числа. Второй метод возвращает квадрат и корень из числа. 
//В основной программе пользователь вводит дробное число. Программа должна вычислить, 
//если это возможно, значение корня, квадрата числа, выделить целую и дробную часть из числа.
namespace Task7
{
	class Program
	{
		public static void Squares(double X, out string SquareRoot, out double Square)
		{
			if (X >= 0)//проверка возможности вычисления квадратного корня, присваивание и условие также можно было оформить как тернарный оператор
			{
				SquareRoot = "= " + Math.Sqrt(X).ToString("0.000");
			}
			else SquareRoot = "не существует";

			Square = X * X;
		}//метод вычисления квадратного корня и квадрата числа
		public static void FractAndWhole(double X, out double Fractional, out double Whole)
		{
			Whole = Math.Floor(X);
			Fractional = X - Math.Floor(X);
		}//метод вычисления целой и дробной частей с помощью округления в меньшую сторону
		public static double ReadDouble()
		{
			double X;

			do
			{
				Console.Write("Введите X = ");
			} while (!double.TryParse(Console.ReadLine(), out X));

			return X;

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число
		static void Main(string[] args)
		{
			do
			{
				double X = ReadDouble();
				double Square, Fractional, Whole;
				string SquareRoot;

				Squares(X, out SquareRoot, out Square);
				FractAndWhole(X, out Fractional, out Whole);

				Console.WriteLine($"Целая часть Х равна {Whole}, дробная часть Х равна {Fractional:F3}, Х в квадрате равен {Square:F3}, квадратный корень из Х {SquareRoot}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}//вызов методов чтения и рассчетов, вывод полученных данных с форматированием, предусмотрено повторное решение
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Получить от пользователя три вещественных числа и проверить для них неравенство треугольника. 
//Оператор if не применять. Точность вывода три знака после запятой.

namespace Task5
{
	class Program
	{
		public static string TriangleInequity(double a, double b, double c)
		{
			string Answer = ((a < b + c) && (b < a + c) && (c < a + b)) ? "выполняется" : "не выполняется";
			return Answer;
		}//метод осуществляет проверку неравенства треугольника для трех чисел с помощью тернарного оператора
		public static double ReadDouble(string Name)
		{
			double X;

			do
			{
				Console.Write("Введите {0} число ", Name);
			} while (!double.TryParse(Console.ReadLine(), out X));//считывание входных данных

			return X;

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число
		static void Main(string[] args)
		{
			do//предусмотрено повторное решение
			{
				double A = ReadDouble("первое");//входные данные
				double B = ReadDouble("второе");
				double C = ReadDouble("третье");

				Console.WriteLine($"Для чисел {A:F3}, {B:F3} и {C:F3} неравенство треугольника {TriangleInequity(A, B, C)}");//выходные данные
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}//происходит вызов методов считывания и проверки неравенства треугольника, затем данные выводятся, предусмотрено повторное решение
	}
}

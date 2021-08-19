using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Пользователь последовательно вводит целые числа.Для хранения полученных чисел в программе используется одна переменная.
//Окончание ввода чисел определяется либо желанием пользователя, либо когда сумма уже введённых отрицательных чисел становится меньше -1000. 
//Определить и вывести на экран среднее арифметическое отрицательных чисел.


namespace Task2
{
	class Program
	{
		public static double Read()
		{
			double In;

			do
			{
				Console.WriteLine("Введите следующее число.");
			} while (!double.TryParse(Console.ReadLine(), out In));
			return In;
		}

		public static double FindAverage()
		{

			double numberOfNegatives = 0, summOfNegatives = 0;

			string test = "";
			do
			{
				double input = Read();

				//Console.WriteLine(input);
				numberOfNegatives = input < 0 ? numberOfNegatives + 1 : numberOfNegatives;
				//Console.WriteLine(summOfNegatives);
				summOfNegatives = input < 0 ? summOfNegatives + input : summOfNegatives;
				Console.WriteLine("Если хотите закончить ввод чисел, нажмите 01");
				test = Console.ReadLine();
			} while (summOfNegatives >= -1000 && test != "01");


			return (summOfNegatives / numberOfNegatives);
		}
		static void Main(string[] args)
		{
			do
			{
				Console.WriteLine(FindAverage());

				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

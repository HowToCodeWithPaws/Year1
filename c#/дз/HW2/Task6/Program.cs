using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Получить от пользователя вещественное значение – бюджет пользователя и целое число
//– процент бюджета, выделенный на компьютерные игры. Вычислить и вывести на экран сумму
//в рублях\евро или долларах, выделенную на компьютерные игры. Использовать спецификаторы формата для валют.

namespace Task6
{
	class Program
	{
		public static double Count(double Number, uint Percent)
		{
			double Answer = Number * Percent / 100;
			return Answer;
		}//метод рассчитывает и возвращает данный процент от данного числа
		public static void Read(out double Budget, out uint Percentage)
		{
			do
			{
				Console.Write("Введите ваш бюджет ");
			} while (!double.TryParse(Console.ReadLine(), out Budget));
			do
			{
				Console.Write("Введите процент вашего бюджета, выделенный на компьютерные игры ");
			} while (!uint.TryParse(Console.ReadLine(), out Percentage) || !(0 <= Percentage) || !(Percentage <= 100));

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число, также проверяется, чтобы число процентов лежало от 0 до 100
		static void Main(string[] args)
		{
			do
			{
				double Budget;//входные данные
				uint Percentage;
				Read(out Budget, out Percentage);

				Console.WriteLine($"На компьютерные игры выделено {Count(Budget, Percentage):c3} рублей");//выходные данные
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}//вызывается метод чтения с консоли и метод рассчета конечной суммы, она форматируется как валюта, предусмотрено повторное решение
	}
}

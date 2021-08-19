using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Получить от пользователя четырехзначное натуральное число и напечатать его цифры в обратном порядке.

namespace Task4
{
	class Program
	{
		public static string Reverse(string Input)
		{
			string reverse = String.Empty;//пустая строка для добавления "перевернутых" цифр вводимого числа

			for (int i = 0; i < 4; i++)
			{
				reverse += Input[3 - i];
			}

			return reverse;
		}//происходит посимвольная склейка строки для выходных данных с элементами введенной строки в обратном порядке
		public static void Read(out string Input)
		{
			uint X;
			do
			{
				Console.Write("Введите ваше четырехзначное число ");
				Input = Console.ReadLine();
			} while (!uint.TryParse(Input, out X) || !(999 < X) || !(X < 10000));//считывание входных данных

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число, также осуществляется проверка четырехзначности числа
		static void Main(string[] args)
		{
			do
			{

				Read(out string Input);

				Console.WriteLine($"Ваше число в обратном порядке: {Reverse(Input)}");//выходные данные
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}//вызывается считывание данных, метод, переворачивающий строку и происходит вывод новой строки, предусмотрено повторное решение
	}
}

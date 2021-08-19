using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Ввести натуральное трехзначное число Р. Найти наибольшее целое число, 
//которое можно получить, переставляя цифры числа Р.

namespace HW2
{
	class Program
	{
		public static string NewNumber(char[] figures)
		{
			string NewNumberLine = String.Empty;//пустая строка для выходных данных

			for (int i = 0; i < 3; i++)
			{
				NewNumberLine += figures[i];//к пустой строке доклеиваится каждый элемент массива
			}
			return NewNumberLine;
		}//метод получает на вход отсортированный в порядке убывания массив из цифр числа, а затем создает из него строку
		public static char[] Sort(string Input)
		{
			char[] figures = { Input[0], Input[1], Input[2] };//создаем массив, элементы которого - цифры числа, введенного в виде строки

			Array.Sort(figures);
			Array.Reverse(figures);
			return figures;
		}//метод сортирует по возрастанию массив из цифр вводимого числа, затем "переворачивает" его
		public static void Read(out string Input)
		{
			uint X;
			do
			{
				Console.Write("Введите ваше трехзначное число ");
				Input = Console.ReadLine();
			} while (!uint.TryParse(Input, out X) || !(99 < X) || !(X < 1000));//считывание входных данных

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число, также осуществляется проверка длины числа
		static void Main(string[] args)
		{
			do
			{

				Read(out string Input);
				char[] figures = Sort(Input);//массив, который состоит из цифр числа, цифры сортировать удобнее как его элементы

				Console.WriteLine($"Самое большое число, которое можно составить из цифр вашего числа: { NewNumber(figures)}");//выходные данные
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}//происходит вызов методов считывания и сортировки цифр в числе по убыванию (в форме массива), затем метод преобразования массива в строку и ее вывод
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIDecoder
{
	class Program
	{
		static void Main(string[] args)
		{
			int Code;/* входные данные, вводимый с экрана Код */

			Console.WriteLine("Введите число от 32 до 127");

			bool Read = int.TryParse(Console.ReadLine(), out Code);/* считывание строки и преобразование строки в число */

			if (Read)/* проверка преобразования строки */
			{/* выходные данные, приведение Кода к типу char, вывод символа ASCII таблицы*/
				Console.WriteLine($"{(Char)Code}");
			}
			else
			{
				Console.WriteLine("Ошибка ввода");
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task05
{
	class Program
	{
		static void Main(string[] args)
		{
			double Cathetus1; double Cathetus2; /* входные данные, длины катетов */

			Console.WriteLine("Введите длину первого катета"); /* считывание длин катетов с консоли и преобразование строк в числа*/
			bool Read1 = double.TryParse(Console.ReadLine(), out Cathetus1);

			Console.WriteLine("Введите длину второго катета");
			bool Read2 = double.TryParse(Console.ReadLine(), out Cathetus2);

			if(Read1 && Read2) /* проверка преобразования строк */
			{/* выходные данные, вычисление и вывод длины гипотенузы*/
				Console.WriteLine("Длина гипотенузы равна " + Math.Sqrt(Cathetus1 * Cathetus1 + Cathetus2 * Cathetus2)); 
			}
			else
			{
				Console.WriteLine("Ошибка ввода");
			}	
		}
	}
}

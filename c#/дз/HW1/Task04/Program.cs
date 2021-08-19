using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
	class Program
	{
		static void Main(string[] args)
		{
			double U; double R; /* входные данные, значения напряжения и сопротивления */

			Console.WriteLine("Введите значение напряжения U в электрической цепи "); /* считывание значений с консоли, преобразование строк в числа*/
			bool ReadU = double.TryParse(Console.ReadLine(), out U);

			Console.WriteLine("Введите значение сопротивления R в электрической цепи ");
			bool ReadR = double.TryParse(Console.ReadLine(), out R);

			if (ReadU && ReadR) /* проверка преобразования строк в числа */
			{
				if (R != 0) /* проверка ненулевого знаменателя */
				{ /* выходные данные, вычисление и вывод значений силы тока и мощности */
					Console.WriteLine("Значение силы тока I равно " + (U/R) + "\nЗначение потребляемой мощности P равно " + (U*U/R));
				}
			}
			else
			{
				Console.WriteLine("Ошибка ввода");
			}
		}
	}
}

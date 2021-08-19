using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Подсчитать общее количество автомобилей, проданных всеми филиалами компании за год.
//Вывести максимальное количество автомобилей, проданных филиалом за квартал, а также название филиала и номер квартала.
//Вывести название филиала, который продал максимальное количество автомобилей по результатам года, а также проданное филиалом количество автомобилей.
//Вывести наиболее успешный квартал, в котором компания показала наилучший результат по продажам(учитываются все филиалы), а также количество автомобилей проданное в нем.

namespace Task5
{
	class Program
	{
		static string[] Filials = { "Западный", "Центральный", "Восточный" };
		static string[] Kvartal = { "I", "II", "III", "IV" };
		static int[,] auto = { { 20, 24, 25 }, // I
                { 21, 20, 18 }, // II
                { 23, 27, 24 }, // III
                { 22, 19, 20 }  // IV
        };

		private static string PrintSrc()
		{
			string st = "Исходные данные:\r\n\\\t";
			foreach (var item in Filials)
			{
				st += item + "\t";
			}
			st += "\r\n";
			for (int i = 0; i < auto.GetLength(0); i++)
			{
				st += Kvartal[i] + "\t";
				for (int j = 0; j < auto.GetLength(1); j++)
					st += auto[i, j] + "\t\t";
				st += "\r\n";
			}
			return st;
		}

		private static string Print()
		{
			return @"Выберите, что вы желаете сделать:
     1. Вычислить общее количество автомобилей;
     2. Вывести максимальное количество автомобилей, проданных филиалом за квартал (название филиала и номер квартала);
     3. Найти название филиала, который продал максимальное количество    автомобилей по результатам года (и число проданных);
     4. Найти наиболее успешный квартал (номер квартала и число проданных);
     0. Завершить работу.
     Ваш выбор: ";
		}

		public static string PrintResults(string mode)
		{
			string st = "";
			int Nstroki;    // номер строки
			int Nstolbca;   // номер столбца
			int SumFilial;       // продано филиалом
			int NFiliala_MaxAutoYear; // номер лучшего филиала
			int MaxAutoFilialZaGod;  // продано лучшим филиалом за год
			int SumKvartal;         // продано за квартал
			int NKvartal_MaxAuto;   // номер квартала с максимальной продажей
			int MaxAutoKvartal;     // максимальная продажа в квартал  

			switch (mode)
			{
				case "0": st += "Спасибо за работу!\r\n"; break;
				case "1":
					st += "Ответ 1. Общее количество автомобилей = " +
					GrandTotal() + "\r\n"; break;
				case "2":
					GetMax4Kvartal(out Nstroki, out Nstolbca);
					st += "Ответ 2. Mаксимальное количество автомобилей = " +
					   auto[Nstroki, Nstolbca] + ", Квартал = " + Kvartal[Nstroki] + ", Филиал = " + Filials[Nstolbca] + "\r\n"; break;
				case "3":
					maxAutoFilialZaGod(out NFiliala_MaxAutoYear, out MaxAutoFilialZaGod);
					st += "Ответ 3. Название филиала, который продал максимальное количество автомобилей по результатам года = " +
						   Filials[NFiliala_MaxAutoYear] +
						   ", проданное количество автомобилей = " + MaxAutoFilialZaGod + "\r\n"; break;
				case "4":
					maxAutoKvartal(out NKvartal_MaxAuto, out MaxAutoKvartal);
					st += "Ответ 4. Наиболее успешный квартал = " + Kvartal[NKvartal_MaxAuto] + ", проданное количество автомобилей = " + MaxAutoKvartal + "\r\n"; break;
				default: st += "Неизвестный режим. Введите число [0..4]\r\n"; break;
			}
			return st;

		}

		private static int GrandTotal()
		{
			int sum = 0;
			foreach (int element in auto)
			{
				sum += element;
			}
			return sum;
		}

		private static void maxAutoFilialZaGod(out int NFiliala_MaxAutoYear, out int MaxAutoFilialZaGod)
		{
			NFiliala_MaxAutoYear = 0;
			MaxAutoFilialZaGod = 0;

			int[] sum = new int[auto.GetLength(1)];
	
			for (int i = 0; i < auto.GetLength(1);++i) {
				for (int j = 0; j < auto.GetLength(0); ++j)
				{
					sum[i] += auto[j, i];
				}
			}

			for (int i = 0; i < sum.Length; i++)
			{
				if (sum[i] == sum.Max())
				{
					NFiliala_MaxAutoYear = i;
					MaxAutoFilialZaGod = sum[i];
				}
			}
		}

		private static void maxAutoKvartal(out int NKvartal_MaxAuto, out int MaxAutoKvartal)
		{
			NKvartal_MaxAuto = 0;
			MaxAutoKvartal = 0;

			int[] sum = new int[auto.GetLength(0)];
			for (int j = 0; j < auto.GetLength(1); ++j)
			{
				for (int i = 0; i < auto.GetLength(0); i++)
				{
					sum[i] += auto[i, j];
				}
			}

			for (int i = 0; i < sum.Length; i++)
			{
				if (sum[i] == sum.Max())
				{
					NKvartal_MaxAuto = i;
					MaxAutoKvartal = sum[i];
				}
			}
		}


		private static void GetMax4Kvartal(out int Nstroki, out int Nstolbca)
		{
			Nstroki = 0;
			Nstolbca = 0;
			for (int i = 0; i < auto.GetLength(0); i++)
				for (int j = 0; j < auto.GetLength(1); j++)
					if (auto[Nstroki, Nstolbca] < auto[i, j])
					{
						Nstroki = i;
						Nstolbca = j;
					}
		}

		static void Main()
		{
			string s, input;

			Console.Write(PrintSrc()); // печать исходных данных

			do
			{
				Console.Write(Print()); // вывод текстового меню
										// обработка выбранного пункта меню + вывод результата
				s = PrintResults(input = Console.ReadLine());

				Console.WriteLine(s);

			} while (input != "0"); // выход из меню по нулю
			Console.ReadLine();
		}

	}
}

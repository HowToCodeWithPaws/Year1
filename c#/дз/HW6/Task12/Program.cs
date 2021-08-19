using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Сформировать массив ссылок на вещественные массивы D, число элементов получить от пользователя.Количество элементов в каждом вещественном массиве равно индексу в D, увеличенному на единицу.Элементы вещественных массивов - случайные значениями из диапазона (0;1). Написать метод, преобразующий массив ссылок на вещественные массивы в двумерный вещественный массив.Недостающие элементы обнулить.Обработать массив D при помощи этого метода, экран вывести D, результат преобразования и суммы элементов для каждого столбца.Точность вывода: два знака после запятой.

namespace Task12
{
	class Program
	{

		/// <summary>
		/// Метод печатает двумерный массив, переданный по ссылке, 
		/// разделяя строки переносами и элементы отступами в 
		/// вложенных циклах for для измерений массива.
		/// </summary>
		/// <param name="array"> Ссылка на массив. </param>
		public static void PrintArray(int[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write("{0,3}", array[i, j]);
				}
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			int[,] ARRAY = new int[2,3];
			for (int i = 0; i < ARRAY.GetLength(0); i++)
			{
				for (int j = 0; j < ARRAY.GetLength(1); j++)
				{
					ARRAY[i, j] = j + i;
				}
			}

			PrintArray(ARRAY);

			int[][] newArray = new int[ARRAY.GetLength(0)][];

			for (int i = 0; i < ARRAY.GetLength(0); i++)
			{
				newArray[i]= new int[ARRAY.GetLength(1)];
				for (int j = 0; j < ARRAY.GetLength(1); j++)
				{
					newArray[i][j] = ARRAY[i,j];
				}
			}
			Console.WriteLine();

			foreach (int[] arrays in newArray)
			{
				foreach (int item in arrays)
				{
					Console.Write($"{item}");
				}
				Console.WriteLine();
			}
		}
	}
}

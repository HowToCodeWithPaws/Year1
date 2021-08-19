using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Работа с элементами массивов массивов и многомерных массивов
//Получить от пользователя целые числа n > 1 и m > 1. Сформировать двумерный массив размера nxm и заполнить его случайными числами из диапазона[-100;100). Выполнить следующие преобразования:
//Заменить максимальный по модулю элемент каждой строки на противоположный по знаку;
//Вставить после каждой строки с чётным индексом нулевую строку;
//Удалить все строки, содержащие хотя бы одно нулевое значение;
//Поменять местами средние столбцы.
//После каждого преобразования матрицу выводить на экран.
//Все преобразования оформить методами.
//Предложить реализацию задачи с использованием массива массивов.
//для массива массивов все идентично, только измерения надо рассматривать как массивы.

namespace Task8
{
	class Program
	{
		private static void ReplaceByNegative(int[,] array)
		{
			for (uint i = 0; i < array.GetLength(0); i++)
			{
				int max = int.MinValue;
				uint remI = 0, remJ = 0;

				for (uint j = 0; j < array.GetLength(1); j++)
				{
					if (array[i, j] > max)
					{
						max = array[i, j];
						remI = i;
						remJ = j;
					}
				}

				array[remI, remJ] = -array[remI, remJ];
			}

			Console.WriteLine("\nMatrix with maxima replaced by negatives\n");
			PrintArray(array);
		}

		private static void InsertZero(ref int[,] array)
		{
			int rows = array.GetLength(0) % 2 == 0 ? array.GetLength(0) + array.GetLength(0) / 2
				: array.GetLength(0) + array.GetLength(0) / 2 + 1;
			int[,] newArray = new int[rows, array.GetLength(1)];

			int iOld = 1;

			for (int j = 0; j < newArray.GetLength(1); j++)
			{
				newArray[0, j] = newArray[1, j] = array[0, j];
			}

			for (int i = 2; i < newArray.GetLength(0); i++)
			{
				switch (i % 3)
				{
					case 0:
						for (int j = 0; j < newArray.GetLength(1); j++)
						{
							newArray[i, j] = array[iOld, j];
						}
						iOld++;
						break;
					case 1:
						for (int j = 0; j < newArray.GetLength(1); j++)
						{
							newArray[i, j] = array[0, j];
						}
						break;
					case 2:
						for (int j = 0; j < newArray.GetLength(1); j++)
						{
							newArray[i, j] = array[iOld, j];
						}
						iOld++;
						break;
				}
			}

			array = newArray;

			Console.WriteLine("\nMatrix with added 0 row\n");
			PrintArray(array);
		}

		private static void DeleteWithZeros(ref int[,] array)
		{
			int rows = array.GetLength(0);
			bool[] flag = new bool[array.GetLength(0)];

			for (int i = 0; i < flag.Length; i++)
			{
				flag[i] = true;
			}

			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (array[i, j] == 0)
					{
						rows--;
						flag[i] = false;
					}
				}
			}

			int iOld = 0;
			int[,] newArray = new int[rows, array.GetLength(1)];
			for (int i = 0; i < newArray.GetLength(0); i++)
			{
				if (flag[iOld])
				{
					for (int j = 0; j < array.GetLength(1); j++)
					{
						newArray[i, j] = array[iOld, j];
					}
				}
				else
				{
					iOld++;
					for (int j = 0; j < array.GetLength(1); j++)
					{
						newArray[i, j] = array[iOld, j];
					}
				}

				iOld++;
			}
			array = newArray;
			Console.WriteLine("\nArray with deleted rows with 0\n");
			PrintArray(array);
		}

		private static void SwapMiddle(int[,] array)
		{
			if (array.GetLength(1) % 2 > 0)
			{
				Console.WriteLine("\nMatrix with swapped middle columns\n\nSorry, this method cannot be applied to a matrix of this size");
			}
			else
			{
				for (int j = 0; j < array.GetLength(0); j++)
				{
					int temp = array[j,array.GetLength(1) / 2 - 1];
					array[j,array.GetLength(1) / 2 - 1] = array[j,array.GetLength(1) / 2];
					array[j,array.GetLength(1) / 2] = temp;
				}

				Console.WriteLine("\nMatrix with swapped middle columns\n");
				PrintArray(array);
			}
		}

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
					Console.Write("{0,5}", array[i, j]);
				}
				Console.WriteLine();
			}
		}

		public static uint Read(string message, uint minvalue = uint.MinValue, uint maxvalue = uint.MaxValue)
		{
			uint input;

			do
			{
				Console.Write(message);
			} while (!uint.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}
		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				uint nRows, mColumns;
				nRows = Read("Input the number of rows (>1): ", 2);
				mColumns = Read("Input the number of columns (>1): ", 2);

				int[,] array = new int[nRows, mColumns];

				Random rand = new Random();

				for (int i = 0; i < array.GetLength(0); i++)
				{
					for (int j = 0; j < array.GetLength(1); j++)
					{
						array[i, j] = rand.Next(-100, 100);
					}
				}

				Console.WriteLine("\nThe original matrix\n");
				PrintArray(array);

				ReplaceByNegative(array);

				InsertZero(ref array);

				DeleteWithZeros(ref array);

				SwapMiddle(array);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

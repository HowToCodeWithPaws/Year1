using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Формирование массивов массивов и многомерных массивов
//Сформировать и заполнить случайными значениями целочисленную матрицу размером MxN(M и N задаются с клавиатуры). На экран вывести сумму и произведение элементов k-ой строки(k – задается с клавиатуры).
//Сформировать и заполнить случайными значениями вещественную матрицу размером MxN(M и N задаются с клавиатуры). На экран вывести сумму элементов для каждого столбца.
//Написать метод, формирующий по целочисленной матрице MxN (M и N задаются с клавиатуры) одномерный массив индексов A.В А
//хранятся индексы столбцов матрицы в отсортированном виде, в порядке возрастания сумм элементов столбцов. В основной программе сформировать матрицу, 
//получить индексный массив, использовать его для вывода столбцов матрицы в порядке возрастания сумм их элементов.

namespace Task7
{
	class Program
	{
		/// <summary>
		/// Метод печатает двумерный массив, переданный по ссылке, 
		/// разделяя строки переносами и элементы отступами в 
		/// вложенных циклах for для измерений массива.
		/// </summary>
		/// <param name="array"> Ссылка на массив. </param>
		public static void PrintArrayInt(int[,] array)
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

		/// <summary>
		/// Метод печатает двумерный массив, переданный по ссылке, 
		/// разделяя строки переносами и элементы отступами в 
		/// вложенных циклах for для измерений массива.
		/// </summary>
		/// <param name="array"> Ссылка на массив. </param>
		public static void PrintArrayDouble(double[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write($"{array[i, j]:F2}\t");
				}
				Console.WriteLine();
			}
		}

		private static void CreateMatrixInt(int[,] matrix)
		{
			Random random = new Random();

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = random.Next(-10, 11);
				}
			}
		}

		private static void CreateMatrixDouble(double[,] matrix)
		{
			Random random = new Random();

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = random.Next(-10, 11) + random.NextDouble();
				}
			}
		}

		/// <summary>
		/// Метод выводит сообщение с переданной информацией и осуществляет
		/// считывание переменной указанного типа с использованием метода 
		/// TryParse в цикле do while до тех пор, пока пользователь не введет
		/// данные, для которых осуществится парсинг, также метод принимает
		/// на вход границы значений считываемого числа, соответствие которым
		/// также проверяется внутри условия do while.
		/// </summary>
		/// <param name="message"> Входной параметр выводимого сообщения. </param>
		/// <param name="minvalue"> Входной параметр нижней границы значения 
		/// числа. </param>
		/// <param name="maxvalue"> Входной параметр верхней границы значения
		/// числа. </param>
		/// <returns>Метод возвращает считанные данные, приведенные к требуемому 
		/// типу.</returns>
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
				uint nRows, mColumns, kRow;
				int kMultiple = 1, kSum = 0;

				nRows = Read("Input number of rows: ", 1);
				mColumns = Read("\nInput number of columns: ", 1);

				int[,] matrix1 = new int[nRows, mColumns];

				CreateMatrixInt(matrix1);

				Console.WriteLine("\nInteger matrix:\n");
				PrintArrayInt(matrix1);

				kRow = Read("\nInput the row you want the sum and multiple of: ", 0, nRows - 1);

				for (int i = 0; i < matrix1.GetLength(1); i++)
				{
					kMultiple *= matrix1[kRow, i];
					kSum += matrix1[kRow, i];
				}

				Console.WriteLine($"\nThe summ of the elements of the {kRow} row is: {kSum}\nThe multiple of the elements of the {kRow} row is: {kMultiple}");

				uint[] indexA = new uint[matrix1.GetLength(1)];

				double[] columnsSummInt = new double[matrix1.GetLength(1)];

				for (int i = 0; i < matrix1.GetLength(0); i++)
				{
					for (int j = 0; j < matrix1.GetLength(1); j++)
					{
						columnsSummInt[j] += matrix1[i, j];
					}
				}

				for (int i = 0; i < indexA.Length; i++)
				{
					indexA[i] = (uint)i;
				}

				for (int i = 0; i < indexA.Length - 1; i++)
				{
					for (int j = i + 1; j < indexA.Length; j++)
					{
						if (columnsSummInt[indexA[i]] > columnsSummInt[indexA[j]])
						{
							uint temp = indexA[i];
							indexA[i] = indexA[j];
							indexA[j] = temp;
						}
					}
				}
				Console.WriteLine("\nInteger matrix with sorted columns\n");

				for (int i = 0; i < matrix1.GetLength(0); i++)
				{
					for (int j = 0; j < matrix1.GetLength(1); j++)
					{
						Console.Write("{0,3}", matrix1[i, indexA[j]]);
					}
					Console.WriteLine();
				}

				double[,] matrix2 = new double[nRows, mColumns];

				CreateMatrixDouble(matrix2);

				double[] columnsSumm = new double[matrix2.GetLength(1)];

				for (int i = 0; i < matrix2.GetLength(0); i++)
				{
					for (int j = 0; j < matrix2.GetLength(1); j++)
					{
						columnsSumm[j] += matrix2[i, j];
					}
				}

				Console.WriteLine("\nDecimal matrix\n");

				PrintArrayDouble(matrix2);

				for (int j = 0; j < matrix2.GetLength(1); j++)
				{
					Console.WriteLine($"\nThe summ of the elements in column {j} is {columnsSumm[j]:F2}");
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

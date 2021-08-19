using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuckedUpMatrix
{
	class Program
	{
		public static int Read(string message, int minvalue = int.MinValue, int maxvalue = int.MaxValue)
		{
			int input;

			do
			{
				Console.WriteLine(message);
			} while (!int.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}

		public static void Fill(int[,] array)
		{

			for (int i = 0; i < array.Length-1; i++)
			{
				for (int j = 0; j < array.Length-1; j++)
				{
					if (i % 2 == 0 && j == 0)
					{
						array[i + 1, j] = array[i, j] + 1;
					}

					if (i % 2 > 0 && j==0)
					{
						for (int n = i+1; n >0; n--)
						{
							array[i - 1, j + 1] = array[i, j] + 1;
							if (i < array.GetLength(0)-1&& j < array.GetLength(0) - 1) { i++; j++; }
						}

					}

					if (i == 0 && j % 2 > 0)
					{
						array[i,j+1]=array[i,j]+1;
					}

					if (i==0&&j%2==0&&j!=0)
					{
						for (int n = j+1; n >0; n--)
						{
							array[i + 1, j - 1] = array[i, j] + 1;
							i++;j++;
						}

					}
				}
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
					Console.Write("{0,3}", array[i, j]);
				}
				Console.WriteLine();
			}
		}
		static void Main(string[] args)
		{
		 // С помощью цикла do while с условием нажатия клавиши Enter
		 // (проверка с помощью метода Console.ReadKey()) реализуется возможность
		 // повторного решения задачи по желанию пользователя.
			do
			{
				//			int nSize = Read("Input the matrix size (1<N<20)", 2, 19);

				//			int[,] matrix2 = new int[nSize, nSize];

				//			for (int i = 0; i < nSize; i++)
				//			{
				//				for (int j = 0; j < nSize; j++)
				//				{
				//					matrix2[i, j] = -1;
				//				}
				//			}

				//			matrix2[0, 0] = 1;
				//			matrix2[nSize-1, nSize-1] = nSize * nSize;

				//			Fill(matrix2);
				//PrintArray(matrix2); 

				//			//matrix2[0, 0] = 1;
				//			//for (int i = 1; i < nSize - 1; i++)
				//			//{
				//			//	if (i % 2 == 0)
				//			//	{
				//			//		for (int j = 1; j < nSize; j++)
				//			//		{
				//			//			matrix2[i + 1, j - 1] = matrix2[i, j] + 1;
				//			//		}
				//			//	}
				//			//	else
				//			//	{
				//			//		for (int j = 1 + i; j > 0; j--)
				//			//		{
				//			//			matrix2[i - 1, j + 1] = matrix2[i, j] + 1;
				//			//		}
				//			//	}


				//			//}

				Console.WriteLine($"Pidor\a");
				Console.WriteLine($"Pidor\a");
				Console.WriteLine($"Pidor\a");

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

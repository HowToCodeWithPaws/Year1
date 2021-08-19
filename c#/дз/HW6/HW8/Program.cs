using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//В классе Program, размещённом в файле Program.cs написать:
//Метод CreateMatrix() возвращает целочисленную матрицу размера M, N, заполненную случайными значениями из диапазона[1;10]. М, N – целочисленные параметры метода.
//Метод MatrixMult() возвращает целочисленную матрицу представляющую произведение матриц A и  B, переданных в качестве параметров.Если A и B не могут быть перемножены, метод возвращает значение null.
//Метод MatrixToString() возвращает строку с табличным представлением матрицы (каждая строка матрицы должна при выводе отображаться на новой строке)
//В том же классе разместить код метода Main(), который:
//Получает от пользователя значения размеры двух матриц A и B и формирует их при помощи метода CreateMatrix();
//При помощи метода MatrixMult() формирует матрицу C произведения AxB, если это возможно, в противном случае вывести понятное сообщение.
//Формирует строки-представления матриц A, B и C при помощи метода MatrixToString() и выводит их на экран.
//Если матрицы перемножить невозможно, выводит на экран только строки-представления матриц A, B и сообщение о невозможности их перемножения.

namespace HW8
{
	class Program
	{
		private static uint[,] CreateMatrix(uint rows, uint columns)
		{
			uint[,] matrix = new uint[rows,columns];

			Random random = new Random();

			for (uint i = 0; i < rows; i++)
			{
				for (uint j = 0; j < columns; j++)
				{
					matrix[i, j] = (uint)random.Next(1,11);
				}
			}
			return matrix;
		}

		private static string MatrixToString(uint[,] matrix)
		{
			string matrixForm = "";

			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrixForm += $"{matrix[i, j],5}" ;
				}
				matrixForm += "\n";
			}

			return matrixForm;
		}

		private static uint[,] MatrixMult(uint[,] matrixLeft, uint[,] matrixRight)
		{
			if (matrixLeft.GetLength(1)==matrixRight.GetLength(0))
			{
				uint[,] matrixRes = new uint[matrixLeft.GetLength(0), matrixRight.GetLength(1)];

				for (int i = 0; i < matrixRes.GetLength(0); i++)
				{
					for (int j = 0; j < matrixRes.GetLength(1); j++)
					{
						for (int r = 0; r < matrixLeft.GetLength(1); r++)
						{
							matrixRes[i, j] += matrixLeft[i, r] * matrixRight[r, j];
						}
					}
				}

				return matrixRes;
			}
			return null;
		}

		public static uint Read(string message)
		{
			uint input;

			do
			{
				Console.WriteLine(message);
			} while (!uint.TryParse(Console.ReadLine(), out input)|| input<1);

			return input;
		}

		static void Main(string[] args)
		{
			do
			{

				uint rowsA, rowsB, columnsA, columnsB;

				rowsA = Read("Insert number of rows in matrix A");
				columnsA = Read("Insert number of columnss in matrix A");
				rowsB = Read("Insert number of rows in matrix B");
				columnsB = Read("Insert number of columnss in matrix B");

				uint[,] matrixA = CreateMatrix(rowsA, columnsA);
				uint[,] matrixB = CreateMatrix(rowsB, columnsB);

				uint[,] newMatrix = MatrixMult(matrixA, matrixB);

				if (newMatrix != null)
				{
					Console.WriteLine($"MatrixA: \n{MatrixToString(matrixA)}\nMatrixB: \n{MatrixToString(matrixB)}\nMatrixA*B: \n{MatrixToString(newMatrix)}\n");
				}
				else
				{
					Console.WriteLine($"MatrixA: \n{MatrixToString(matrixA)}\nMatrixB: \n{MatrixToString(matrixB)}\nIt's impossible to multiply A and B, sorry(");
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
			
		}
	}
}

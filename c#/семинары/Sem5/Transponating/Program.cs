using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transponating
{
	class Program
	{
		const int N = 5;
		const int MaxSize = 10;

		static Random random = new Random();

		static void Transpose(int [,] matrix)
		{
			for(int i=0; i<matrix.GetLength(0); ++i)
			{
				for(int j = i; j<matrix.GetLength(1); ++j)
				{
					int temp = matrix[i, j];
					matrix[i, j] = matrix[j, i];
					matrix[j, i] = temp;
				}
			}
		}

		static void Transpose(int[][] matrix)
		{
			for (int i = 0; i < matrix.Length; ++i)
			{
				for (int j = i; j < matrix.Length; ++j)
				{
					int temp = matrix[i][j];
					matrix[i][j] = matrix[j][i];
					matrix[j][i] = temp;
				}
			}
		}

		static void PrintArray(int [,] array)
		{
			for (int i = 0; i < array.GetLength(0); ++i)
			{
				for (int j = 0; j < array.GetLength(1); ++j)
				{
					Console.Write(array[i, j] + " ");
				}

				Console.WriteLine();
			}
		}

		static void PrintArray(int[][] array)
		{
			for (int i = 0; i < array.Length; ++i)
			{
				for (int j = 0; j < array.Length; ++j)
				{
					Console.Write(array[i][j] + " ");
				}

				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			int[,] multiDimArray = new int[N, N];
			for(int i= 0; i<N; ++i)
			{
				for(int j =0; j<N; ++j)
				{
					multiDimArray[i, j] = random.Next(MaxSize);
				}
			}
			Console.WriteLine("MULTI DIM ARRAY");
			PrintArray(multiDimArray);
			Console.WriteLine("MULTI DIM ARRAY TRANSPOSED");
			Transpose(multiDimArray);
			PrintArray(multiDimArray);


			int[][] jaggedArray = new int[N][];
			for (int i = 0; i < N; ++i)
			{
				jaggedArray[i] = new int[N];

				for (int j = 0; j < N; ++j)
				{
					jaggedArray[i][j] = random.Next(MaxSize);
				}
			}
			Console.WriteLine("JAGGED ARRAY");
			PrintArray(jaggedArray);
			Console.WriteLine("JAGGED ARRAY TRANSPOSED");
			Transpose(jaggedArray);
			PrintArray(jaggedArray);
		}
	}
}

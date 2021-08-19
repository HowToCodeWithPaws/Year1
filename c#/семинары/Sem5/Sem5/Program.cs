using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem5
{
	class Program
	{
		const int ArraySize = 10;// better to create constants for numbers which are often-occuring but which meaning is not clear

		// important: never do use Random inside the for cycle that works too fast, as the Seed for random generation won't have enough time
		// to change. Thread.Sleep(n) can be used to stop the programm for n miliseconds in order to play for time, though it's neater to
		// either create a class or initiate it outside the cycle.
		static Random random = new Random();

		static int[] createArray(int size)
		{
			int[] a = new int[size];

			for (int i = 0; i < size; i++)
			{
				a[i] = random.Next(10, 51);
			}

			return a;
		}

		//static void OwnResize(int [] array, int newSize)
		//{
		//	for(int i=0; i <newSize; ++i)
		//	{
		//		int [] newArray = new int [array.Length]
		//	}
		//}

		static void Main(string[] args)
		{
			//int[] array = new int[] { 0, 1, 2, 3 };// ways to initiate an array
			//int[] arrayRe = new int[10];

			//int[,] multiDimArray = new int[4, 5]; // is stored like a very long one-dimensional array
			//int[][] jaggedArray = new int[4][]; // works more efficiently

			int[] a = createArray(ArraySize);
			Console.WriteLine("Array A:");
			foreach (int number in a)
			{
				Console.WriteLine(number);
			}

			int[] b = createArray(ArraySize);
			Console.WriteLine("Array B:");
			foreach (int number in b)
			{
				Console.WriteLine(number);
			}

			int countEven = 0;

			foreach (int number in b)
			{
				if (number % 2 == 0)
				{
					++countEven;
				}
			}

			Array.Resize(ref a, a.Length + countEven);

			for (int i = 0, j = 0; i < b.Length && j < countEven; ++i)
			{
				if (a[i] % 2 == 0)
				{
					++j;
					a[ArraySize + j] = b[i];
				}
			}

			Console.WriteLine("Array A:");
			foreach (int number in a)
			{
				Console.WriteLine(number);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Определить массив из трех элементов – ссылок на массивы разной длины.
//    1-й элемент - массив из 3-х элементов – ссылок на массивы, 
// соответственно, из 2-х, 3-х и 4-х элементов типа char. 
//    2-й элемент - массив из 2-х элементов ссылок на массивы, 
// соответственно, из 2-х и 3-х элементов типа char. 
//    3-й элемент - массив из ОДНОГО элемента – ссылки на массив из 4-х 
// элементов типа char. 
// Используя свойства и методы класса Array вывести ранг массива,
// общее число его элементов, число элементов по разным 
// измерениям, предельные значения всех индексов. 
// Вывести элементы массива с помощью циклов foreach,  размещая 
// значения элементов каждого массива нижнего уровня по строкам...

namespace Task2
{
	class Program
	{
		public static void Initiate(char[][][] array)
		{

			array[0] = new char[][]{
						new char[] {'a','b'},
						new char[] {'c','d','e'},
						new char[] {'f','g','h','i'}};
			array[1] = new char[][]{
						new char[] {'j','k'},
						new char[] {'l','m','n'}};
			array[2] = new char[][] {
						new char[] { 'o', 'p', 'q', 'r' } };
		}

		public static void GetInfo(char[][][] array)
		{
			Console.WriteLine($"array.Rank: {array.Rank}\narray.Length: {array.Length}" +
				$"\narray[0].GetLength(0): {array[0].GetLength(0)}\narray[1].GetLength(0): {array[1].GetLength(0)}" +
				$"\narray[2].GetLength(0): {array[2].GetLength(0)}\narray[0].GetUpperBound(0): {array[0].GetUpperBound(0)}" +
				$"\narray[1].GetUpperBound(0): {array[1].GetUpperBound(0)}\narray[2].GetUpperBound(0): {array[2].GetUpperBound(0)}");
		}

		
		public static void Print(char[][][] array)
		{
			foreach(char[][] ch1 in array)
			{
				foreach(char[] ch2 in ch1)
				{
					foreach(char ch3 in ch2)
					{
						Console.Write(ch3+" ");
					}
					Console.WriteLine();
				}
			}
		}

		static void Main(string[] args)
		{
			do
			{
				char[][][] arrayTop = new char[3][][];

				Initiate(arrayTop);

				GetInfo(arrayTop);

				Print(arrayTop);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

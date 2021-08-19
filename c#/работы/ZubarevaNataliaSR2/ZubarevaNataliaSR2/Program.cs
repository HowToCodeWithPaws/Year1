using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Самостоятельная работа
// БПИ199:2
// Зубарева Наталия
// 13.11.2019
// Вариант 2

namespace ZubarevaNataliaSR2
{
	class Program
	{
		/// <summary>
		/// Метод получает ссылку на массив массивов, затем в двух
		/// циклах foreach выводит элементы массива, печатая внутренние массивы
		/// построчно, а элементы в них с отступом.
		/// Альтернативно можно было бы выводить массив в двух циклах for.
		/// </summary>
		/// <param name="array"> Метод принимает ссылку на выводимый массив. </param>
		public static void PrintArray(int[][] array)
		{
			foreach (int[] item in array)
			{
				foreach (int number in item)
				{
					Console.Write("{0,5}", number);
				}
				Console.WriteLine(Environment.NewLine);
			}
		}

		/// <summary>
		/// Метод заполняет двумерный массив случайными числами от 0 до 9.
		/// </summary>
		/// <param name="array"> Метод получает ссылку на массив. </param>
		/// <param name="columnSize"> Метод получает размер второго измерения
		/// массива. </param>
		public static void Fill(int[][] array, uint columnSize)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				array[i] = new int[columnSize];

				for (int j = 0; j < columnSize; j++)
				{
					array[i][j] = random.Next(0, 10);
				}
			}
		}

		/// <summary>
		/// Метод меняет местами i-тый элемент заданной строки с
		/// i-тым элементов заданного столбца.
		/// </summary>
		/// <param name="array"></param>
		public static void Change(int[][] array)
		{
			// Переменные для номера строки и столбца.
			uint rowIndex, columnIndex;

			// Вызов считывания с консоли.
			rowIndex = Read("Введите номер строки, элементы " +
				"которой мы будем менять", 0, (uint)array.GetLength(0) - 1);
			columnIndex = Read("Введите номер столбца, элементы " +
				"которого мы будем менять", 0, (uint)array[0].Length - 1);

			// Поиск минимального из измерений.
			int min = array.GetLength(0) <= array[0].Length ? array.GetLength(0)
				: array[0].Length;

			Console.WriteLine($"Меняем местами элементы {rowIndex}строки " +
				$"и {columnIndex}столбца");

			// Замена элементов через вспомогательную переменную, альтернативно можно было сделать 
			// через вычитание.
			for (int i = 0; i < min; i++)
			{
				int tmp = array[rowIndex][i];
				array[rowIndex][i] = array[i][columnIndex];
				array[i][columnIndex] = tmp;
			}
		}

		/// <summary>
		/// Публичный статический класс, генерирующий случайные числа.
		/// </summary>
		public static Random random = new Random();

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
		public static uint Read(string message, uint minvalue = uint.MinValue,
			uint maxvalue = uint.MaxValue)
		{
			uint input;

			do
			{
				Console.WriteLine(message);
			} while (!uint.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}

		/// <summary>
		/// В методе мейн происходит объявление и считывание размеров массива, 
		/// объявление и инициализация массива, затем вызов методов, работающих с ним.
		/// Также внутри метода все расположено в цикле do while, реализующем повторное
		/// решение при желании пользователя.
		/// </summary>
		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Переменные для размеров массива.
				uint rowSize, columnSize;

				// Считывание переменных с внутренней проверкой корректности ввода.
				rowSize = Read("Введите количество строк в массиве, целое " +
					"число от 1 до 99", 1, 99);
				columnSize = Read("Введите количество столбцов в массиве, целое" +
					" число от 1 до 99", 1, 99);

				// Объявление и инициализация массива.
				int[][] array = new int[rowSize][];

				// Вызов метода, заполняющего массив.
				Fill(array, columnSize);

				// Вызов метода печати массива.
				Console.WriteLine("Заполненный массив:");
				PrintArray(array);

				// Вызов метода изменения массива.
				Change(array);

				// Вызов метода печати массива.
				Console.WriteLine("Измененный массив:");
				PrintArray(array);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

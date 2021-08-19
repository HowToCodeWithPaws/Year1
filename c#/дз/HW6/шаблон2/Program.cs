using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace шаблон2
{
	class Program
	{
		/// <summary>
		/// Метод принимает ссылку на массив массивов и заполняет его 
		/// массивами ввдененного размера, затем приравнивает значение 
		/// каждой ячейки к случайному числу.
		/// </summary>
		/// <param name="array"> Метод принимает ссылку на заполняемый
		/// массив. </param>
		public static void FillArray(int[][] array)
		{
			// В цикле for в каждую ячейку наружнего массива кладется 
			// массив размера считанного с консоли с помощью метода Read.
			for (int i = 0; i <array.GetLength(0); i++)
			{
				uint sizeOfInnerArray = Read($"Введите длину массива на {i} " +
					$"строке, целое число больше 0", 1);

				array[i] = new int[sizeOfInnerArray];
			}

			// В двух циклах for каждая ячейка заполняется числом из класса
			// Random от 0 до 10.
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array[i].Length; j++)
				{
					array[i][j] = random.Next(0, 11);
				}
			}
		}

		/// <summary>
		/// Метод получает ссылку на массив массивов, затем в двух
		/// циклах foreach выводит элементы массива, печатая внутренние массивы
		/// построчно, а элементы в них с отступом.
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
		/// Статический класс генерирует случайное число. 
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
		/// В методе мейн объявляется и считывается с помощью метода Read переменная
		/// размера массива, инициализируется массив массивов, вызывается метод, 
		/// заполняющий его, затем вызывается метод вывода массива на экран. Все это
		/// происходит внутри цикла do while, реализующего возможность повторного решения.
		/// </summary>
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Переменная целого беззнакового типа для количества строк в массиве.
				uint numberOfRows;

				// Вызов метода считывания для размера массива.
				numberOfRows = Read("Введите число строк в массиве, целое число большее 0", 1);

				// Объявление и инициализация массива массивов.
				int[][] array = new int[numberOfRows][];

				// Вызов метода заполнения массива.
				FillArray(array);

				// Вызов метода печати массива.
				PrintArray(array);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}

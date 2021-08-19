using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace шаблон3
{
	class Program
	{

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
				Console.WriteLine(message);
			} while (!uint.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
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
		public static double ReadDouble(string message, double minvalue = double.MinValue, double maxvalue = double.MaxValue)
		{
			double input;

			do
			{
				Console.WriteLine(message);
			} while (!double.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
		}

		public static void Fill(double[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				array[i, 0] = ReadDouble($"Введите первое число в строке {i}, дробные числа вводите через запятую");
				for (int j = 0; j < array.GetLength(1)-1; j++)
				{
					array[i, j + 1] = array[i, j] + 2;
				}
			}
		}


		/// <summary>
		/// Метод печатает двумерный массив, переданный по ссылке, 
		/// разделяя строки переносами и элементы отступами в 
		/// вложенных циклах for для измерений массива.
		/// </summary>
		/// <param name="array"> Ссылка на массив. </param>
		public static void PrintArray(double[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write("{0,8}", array[i, j]);
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
				uint size = Read("Введите количество строк в массиве, целое число больше 0", 0);

				double[,] array = new double[size, 10];

				Fill(array);

				PrintArray(array);

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//В программе создать матрицу размеров NxN(1 < N< 20 – вводится с клавиатуры пользователем.Заполнить матрицу числами от 1 до N2, в направлениях, указанных стрелками на рисунках ниже.Полученные матрицы вывести на экран.

namespace Task9
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
		public static int Read(string message, int minvalue = int.MinValue, int maxvalue = int.MaxValue)
		{
			int input;

			do
			{
				Console.WriteLine(message);
			} while (!int.TryParse(Console.ReadLine(), out input) || input < minvalue || input > maxvalue);

			return input;
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

				int nSize = Read("Input the matrix size (1<N<20)", 2, 19);

				int[,] matrix1 = new int[nSize, nSize];
				for (int i = 0; i < matrix1.GetLength(1); i++)
				{
					if (i % 2 == 0)
					{
						for (int j = 0; j < matrix1.GetLength(0); j++)
						{
							matrix1[j, i] = i * 6 + j + 1;
						}
					}
					else
					{
						for (int j = matrix1.GetLength(0) - 1; j >= 0; j--)
						{
							matrix1[j, i] = i * 6 + matrix1.GetLength(0) - j;
						}
					}
				}

				PrintArray(matrix1);

				

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

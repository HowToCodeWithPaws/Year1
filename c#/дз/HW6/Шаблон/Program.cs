using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//На ввод дается N, это количество строк в массиве.Заполнение массивов происходит по i количеству элементов, 
//	элемент прогрессирует в арифметической прогрессии.
//То есть: При N = 3
//1
//2 3
//4 5 6


namespace Шаблон
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

		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				uint linesNumber = Read("Введите количество строк в массиве", 1);

				uint[][] array = new uint[linesNumber][];

				for (int i = 0; i < linesNumber; i++)
				{
					array[i] = new uint[i + 1];
				}

				array[0][0] = 1;

				for (int i = 1; i < linesNumber; i++)
				{
					array[i][0] = array[i - 1][0] + (uint)i;
					for (int j = 1; j < array[i].Length; j++)
					{
						array[i][j] = array[i][j - 1] + 1;
					}
				}


				foreach (uint[] smolArray in array)
				{
					foreach (uint item in smolArray)
					{
						Console.Write("{0,3}", item);
					}
					Console.WriteLine();
				}
				string answer = "";

				foreach (uint[] smolArray in array)
				{
					foreach (uint item in smolArray)
					{
						answer+=item+"\t";
					}
					answer+="\n";
				}


				/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
				try
				{
					File.WriteAllText("output.txt", answer);
				}
				catch (IOException)
				{
					Console.WriteLine("Ошибка ввода/вывода");
				}
				catch (UnauthorizedAccessException)
				{
					Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла");
				}
				catch (System.Security.SecurityException)
				{
					Console.WriteLine("Ошибка безопасности");
				}
				finally
				{

				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

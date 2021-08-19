using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
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

		private static IntegerList _list = new IntegerList(10);

		/// <summary>
		/// Создаёт список и выполняет пользовательские операции,
		/// пока пользователь не захочет выйти
		/// </summary>
		public static void Main()
		{
			int choice;

			PrintMenu(out choice);



			while (choice != 0)
			{
				Dispatch(choice);
				PrintMenu(out choice);
			}
			if (choice==0)
			{
				Console.WriteLine("Пока!");
			}
		}

		/// <summary>
		/// Выполняет действия меню
		/// </summary>
		/// <param name="choice">Выбранный пункт меню</param>
		public static void Dispatch(int choice)
		{
			switch (choice)
			{
				case 1:
					int size = Read("Какой размер будет у списка?");
					_list = new IntegerList(size);
					_list.Randomize();
					break;
				case 2: _list.Print(); break;
				case 3: 
					int newVal = Read("Какое число вы хотите добавить?");
					_list.AddElement(newVal);
					break;
				case 4:
					int val = Read("Первое вхождение какого числа вы хотите убрать?");
					_list.RemoveFirst(val);
					break;
				case 5:
					int val2 = Read("Вхождения какого элемента вы хотите убрать?");
					_list.RemoveAll(val2);
					break;
				default: Console.WriteLine("Извините, вы выбрали что-то не то"); break;
			}
		}

		/// <summary>
		/// Выводит варианты пользователю
		/// </summary>
		public static void PrintMenu(out int choice)
		{
			Console.WriteLine("\n Меню ");
			Console.WriteLine(" ====");
			Console.WriteLine("0: Выйти");
			Console.WriteLine("1: Создать новый список (** сделайте это с самого начала!! **)");
			Console.WriteLine("2: Напечатать список");
			Console.WriteLine("3: Добавить элемент");
			Console.WriteLine("4: Убрать первый элемент, равный числу");
			Console.WriteLine("5: Убрать все элементы, равные числу");
			choice = Read("\nВведите ваш выбор: ");
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRIsntToday
{
	public interface ISharper
	{
		int ThrowDices();
	}

	public interface IUnlucky
	{
		int ThrowDices();
	}

	public struct Player : ISharper, IUnlucky
	{
		public static Random random = new Random();

		public int id, numberOfDices;

		public Player(int id_, int numberOfDices_)
		{
			id = id_;
			numberOfDices = numberOfDices_;
		}
		public int ThrowDices()
		{
			int summ = 0;
			for (int i = 0; i < numberOfDices; i++)
			{
				summ += random.Next(1, 7);
			}

			return summ;
		}
		int ISharper.ThrowDices()
		{
			int summ = 0;
			for (int i = 0; i < numberOfDices; i++)
			{
				summ += random.Next(5, 7);
			}

			return summ;
		}
		int IUnlucky.ThrowDices()
		{
			int summ = 0;
			for (int i = 0; i < numberOfDices; i++)
			{
				summ += random.Next(1, 3);
			}

			return summ;
		}
	}

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

		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				int numberOfDices = Read("Введите число костей у игроков: ");

				Player[] players = new Player[10];

				for (int i = 0; i < 10; i++)
				{
					players[i] = new Player(i + 1, numberOfDices);
				}

				foreach (Player player in players)
				{
					Console.WriteLine($"Я игрок {player.id}. Бросаю кости на {player.ThrowDices()} очков.");
					Console.WriteLine($"Я игрок {player.id}. Бросаю кости на { (player as ISharper).ThrowDices()} очков.");
					Console.WriteLine($"Я игрок {player.id}. Бросаю кости на { (player as IUnlucky).ThrowDices()} очков.\n");
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);

		}
	}
}

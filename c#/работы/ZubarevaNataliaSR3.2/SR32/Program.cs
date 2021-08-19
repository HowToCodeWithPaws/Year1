using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

/// Зубарева Наталия
/// Вариант 1
/// 15.02.20

namespace SR32
{
	/// <summary>
	/// Основная программа с повтором решения.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				// Создание судьи и игроков. Альтернативное решение: можно было сделать список игроков.
				Judge judge = new Judge();

				Player[] players = new Player[10];

				// Заполнение, подписка метода, вызов метода Roll, альтернативно
				//можгно было исользовать не лямбду а обычный метод.
				for (int i = 0; i < players.Length; i++)
				{
					players[i] = new Player();
				}

				foreach (Player player in players)
				{
					player.Finished += (object sender, PlayerFinishedEventArgs e)
						=>
					{ judge.PrintFinishedPlayerInfo(player, e.Score); };
				}

				for (int i = 0; i < players.Length; i++)
				{
					players[i].Roll();
				}



				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

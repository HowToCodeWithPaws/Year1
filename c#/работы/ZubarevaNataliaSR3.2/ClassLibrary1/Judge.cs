using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	/// <summary>
	/// Класс для судьи, в котором метод выводит сообщение о текущем состоянии игры.
	/// /// </summary>
	public class Judge
	{
		private Player leader = null;
		private int leaderScore = 0;

		public void PrintFinishedPlayerInfo(Player player, int score)
		{
			if (score > leaderScore)
			{
				leader = player;
				leaderScore = score;
			}
			Console.WriteLine($"{player} finished with score {score}. Leader {leader} is with score {leaderScore}");
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	/// <summary>
	/// Класс для кастомного вида аргументов, имеет поле счета.
	/// </summary>
	public class PlayerFinishedEventArgs : EventArgs
	{
		public int Score { get; }
		public PlayerFinishedEventArgs(int score_)
		{
			Score = score_;
		}
	}
}

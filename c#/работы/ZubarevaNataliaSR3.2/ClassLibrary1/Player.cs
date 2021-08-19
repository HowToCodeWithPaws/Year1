using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	/// <summary>
	/// Класс для игрока с нужными полями и переопределением ТуСтринг.
	/// Есть статическое поле с Id предыдущего игрока.
	/// </summary>
	public class Player
	{
		public static Random random = new Random();
		public int Id { get; }

		static int lastId = -1;

		public Player()
		{
			Id = ++lastId;
		}

		public event EventHandler<PlayerFinishedEventArgs> Finished;

		public void Roll()
		{
			Finished(this, new PlayerFinishedEventArgs(random.Next(1, 7)));
		}

		public override string ToString()
		{
			return "Player " + Id.ToString();
		}
	}
}

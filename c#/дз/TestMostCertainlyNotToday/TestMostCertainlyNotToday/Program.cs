using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMostCertainlyNotToday
{
	class Program
	{
		public static event EventHandler SeasonEvent;
		public static Random random = new Random();


		public static void Thougths(int days) {
			for (int i = 0; i < days; i++)
			{
				object sender = new object();
				DateTime now = DateTime.Now;
				SeasonEvent?.Invoke(sender, new SeasonEventArgs(now.AddDays(random.Next(0,366))));
			}
		}

		static void Main(string[] args)
		{
			SeasonEvent += (object sender, EventArgs day) =>
			{
				if ((day as SeasonEventArgs).Day.DayOfYear >= new DateTime(2020, 06, 1).DayOfYear
				&& (day as SeasonEventArgs).Day.DayOfYear < new DateTime(2020, 09, 1).DayOfYear)

					Console.WriteLine($"{(day as SeasonEventArgs).Day} - ебошь каре");

				else Console.WriteLine($"{(day as SeasonEventArgs).Day} - не сегодня");

			};
			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{

				Thougths(4);


				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);



		}
	}
}
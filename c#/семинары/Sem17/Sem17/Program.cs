using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Sem17
{
	class Program
	{
		public static void OnCarEngineEvent(string message)
		{
			Console.WriteLine("\n***** A message from your car! *****");
			Console.WriteLine($"=> {message}");
			Console.WriteLine("***********************************\n");
		}

		static void Main()
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				Console.WriteLine("***** Using delegates to manage events *****\n");

				Car c1 = new Car("Fleabag", 100, 10);

				c1.RegisterWithCarEngine(new CarEngineHandler(OnCarEngineEvent));

				Console.WriteLine("***** Accelerating *****");
				for (int i = 0; i < 6; i++)
				{
					c1.Accelerate(20);
					Console.ReadLine();
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

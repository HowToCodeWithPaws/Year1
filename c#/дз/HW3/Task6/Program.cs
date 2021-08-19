using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
	class Program
	{
		public static void Compare(uint RoomA, uint RoomB, uint RoomC, out uint result)
		{
			uint A, B, C;
			A = RoomA % 100;
			B = RoomB % 100;
			C = RoomC % 100;

			result = (A <= B) ? ((A <= C) ? (RoomA) : (RoomC)) : ((B <= C) ? (RoomB) : (RoomC));
		}

		static public uint Read(string Name)
		{
			uint In;

			do
			{
				Console.Write($"Введите номер {Name} аудитории ");

			} while (!uint.TryParse(Console.ReadLine(), out In) || (In <= 99) || (In >= 1000));

			return In;
		}

		static void Main(string[] args)
		{
			do
			{
				uint Room1, Room2, Room3, result;

				Room1 = Read("первой");
				Room2 = Read("второй");
				Room3 = Read("третьей");

				Compare(Room1, Room2, Room3, out result);

				Console.WriteLine($"{result}");
				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{

	class Program
	{
		public static Random random = new Random();
		static void Main(string[] args)
		{

			// С помощью цикла do while с условием нажатия клавиши Enter
			// (проверка с помощью метода Console.ReadKey()) реализуется возможность
			// повторного решения задачи по желанию пользователя.
			do
			{
				ArithmeticSequence supremeSequence = new ArithmeticSequence(random.Next(0,1001), random.Next(1,11));

				ArithmeticSequence[] sequences = new ArithmeticSequence[random.Next(5, 16)];
				for (int i = 0; i < sequences.Length; i++)
				{
					sequences[i] = new ArithmeticSequence(random.Next(0, 1001), random.Next(1, 11));
				}

				int step = random.Next(3,16);

				for (int i = 0; i < sequences.Length; i++)
				{
					Console.WriteLine($"\n\nПоследовательность с номером {i}:\nсумма {step} первых членов равна {sequences[i].GetSum(step)}");
					if (sequences[i][step]>supremeSequence[step])
					{
						Console.WriteLine($"Член последовательности с номером {step} больше соответстующего отдельной последовательности:\n{sequences[i][step]}>{supremeSequence[step]}\n" +sequences[i].ToString());
					}
				}


				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

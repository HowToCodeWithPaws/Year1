using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//delegates

namespace Sem16
{
	public delegate double MathOperation(double a, double b);

	public class Calculator
	{
		public static double Calculate(string expr)
		{
			string[] args = expr.Split(' ');
			try
			{
				double operandA = double.Parse(args[0]);
				string operationExp = args[1];
				double operandB = double.Parse(args[2]);

				return Program.operations[operationExp](operandA, operandB);
			}
			catch (Exception) { throw; }
		}
	}

	class Program
	{
		public static Dictionary<String, MathOperation> operations;

		static Program()
		{
			operations = new Dictionary<string, MathOperation>();
			operations.Add("+", (x, y) => { return x + y; });
			operations.Add("-", (x, y) => { return x - y; });
			operations.Add("*", (x, y) => { return x * y; });
			operations.Add("/", (x, y) => { return x / y; });
			operations.Add("^", (x, y) => { return Math.Pow(x, y); });
		}

		public static void FirstTask()
		{
			Console.WriteLine("running the first task");
			try
			{
				string[] expressions = File.ReadAllLines("../../../expressions.txt");
				File.WriteAllText("../../../answers.txt", "");
				foreach (string expr in expressions)
					try
					{
						File.AppendAllText("../../../answers.txt", $"{Calculator.Calculate(expr):f3}\n");
					}
					catch (Exception)
					{
						Console.WriteLine("Неверно введены данные");
					}

				Console.WriteLine("first task finished");
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("Файл не существует" + Environment.NewLine + e);
			}
			catch (IOException e)
			{
				Console.WriteLine("Ошибка ввода/вывода" + Environment.NewLine + e);
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла" + Environment.NewLine + e);
			}
			catch (System.Security.SecurityException e)
			{
				Console.WriteLine("Ошибка безопасности" + Environment.NewLine + e);
			}
		}

		public static string Checker(double left, double right, ref int errors)
		{
			if (left - right < 0.001) { return "OK"; }
			else
			{
				errors++;
			}
			return "Error";
		}

		public static void SecondTask()
		{
			Console.WriteLine("running the second task");
			/// Блок try catch обрабатывает возможные исключения, возникающие при работе с файлами.
			try
			{
				int errors = 0;
				string[] expressions = File.ReadAllLines("../../../expressions_checker.txt");
				string[] answers = File.ReadAllLines("../../../answers.txt");
				File.WriteAllText("../../../results.txt", "");
				for(int i = 0; i< expressions.Length; i++) {
					try
					{
	
						double left = double.Parse(expressions[i]);
						double right = double.Parse(answers[i]);
						File.AppendAllText("../../../results.txt", $"{Checker(left, right, ref errors)}\n");
					}
					catch (Exception)
					{
						Console.WriteLine("Неверно введены данные");
					} }
			}
			catch (FileNotFoundException e)
			{
				Console.WriteLine("Файл не существует" + Environment.NewLine + e);
			}
			catch (IOException e)
			{
				Console.WriteLine("Ошибка ввода/вывода" + Environment.NewLine + e);
			}
			catch (UnauthorizedAccessException e)
			{
				Console.WriteLine("Ошибка доступа: у вас нет разрешения на создание файла" + Environment.NewLine + e);
			}
			catch (System.Security.SecurityException e)
			{
				Console.WriteLine("Ошибка безопасности" + Environment.NewLine + e);
			}
		}

		static void Main()
		{
			do
			{
				FirstTask();

				SecondTask();

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

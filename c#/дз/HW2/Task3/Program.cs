using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Введя значения коэффициентов А, В, С, вычислить корни квадратного уравнения. 
//Учесть (как хотите) возможность появления комплексных корней. Оператор if не применять.

namespace Task3
{

	class Program
	{
		public static string Linear(double b, double c)
		{
			double Solution = -c / b;
			return Solution.ToString("0.000");
		}//метод реализуется, если уравнение не квадратное, вычисляет и больше не выводит его корень
		public static void CheckComplexity(double a, double b, double c, out string Answer1, out string Answer2)
		{
			double Solution1 = Solution("1", a, b, c);
			double Solution2 = Solution("0", a, b, c);

			Answer1 = Double.IsNaN(Solution1) ? "комплексное число" : Solution1.ToString("0.000");
			Answer2 = Double.IsNaN(Solution2) ? "комплексное число" : Solution2.ToString("0.000");
		}//метод вызывает рассчет корней, проверяет их на комплексность в тернарном операторе, присваивает строке для вывода либо их значение, либо строку "комплексное число"
		public static double Solution(string WhichOne, double a, double b, double c)
		{
			double solution;
			double Discr = b * b - 4 * a * c;

			solution = (WhichOne == "1") ? ((-b + Math.Sqrt(Discr)) / (2 * a)) : ((-b - Math.Sqrt(Discr)) / (2 * a));
			return solution;
		}//метод рассчитывает дискриминант и значение корня с использованием тернарного оператора
		public static double ReadDouble(string Name)
		{
			double X;

			do
			{
				Console.Write("Введите коэффициент {0} = ", Name);
			} while (!double.TryParse(Console.ReadLine(), out X));//считывание входных данных

			return X;

		}//метод считывает строку с экрана до тех пор, пока не считает что-то, что сможет преобразовать в число
		static void Main(string[] args)
		{

			do//предусмотрено повторное решение
			{
				double A = ReadDouble("A");
				double B = ReadDouble("B");
				double C = ReadDouble("C");
				string Answer1;
				string Answer2;
				CheckComplexity(A, B, C, out Answer1, out Answer2);

				Console.WriteLine(A != 0 ? $"Корни уравнения Х1 = {Answer1}, Х2 = {Answer2}" : B != 0 ? $"Ваше уравнение линейное, его корень Х = { Linear(B, C) }" : "Уравнение некорректно");

				//выходные данные
				//	if (A != 0)//проверка коэффициентов       код мог быть вот таким красивым если бы не это все
				//		{
				//			CheckComplexity(A, B, C);
				//		}
				//  else
				//		{
				//			if (B != 0)
				//				{
				//					Linear(B, C);
				//				}
				//			else Console.WriteLine("Уравнение некорректно");
				//		}

				Console.WriteLine("Для повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);


		}//происходит вызов метода считывания, присвоение считанных данных переменным, проверка коэффициентов и ветвление алгоритма в зависимости от типа уравнения, а также вывод данных теперь
	}
}

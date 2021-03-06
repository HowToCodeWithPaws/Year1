using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Дано четырехзначное число. Определите, является ли его десятичная запись симметричной. 
//Если число симметричное, то выведите 1, иначе выведите любое другое целое число. 
//При решении этой задачи запрещается пользоваться тернарной операцией, условной инструкцией if, 
//оператором switch и циклами за исключеним использования условного оператора if для проверки ввода
namespace Task2
{
	class Program
	{
		/// <summary>
		/// Метод получает на вход четырехзначное число, составляет из первых двух его цифр и последних двух цифр в 
		/// обратном порядке две переменные и сравнивает их без использования условных или тернарных операторов
		/// с помощью вычитания: если число симметрично, разность переменных будет равна 0 и результат = 0 + 1 = 1,
		/// иначе - другому целому числу.
		/// </summary>
		/// <param name="Number">Вводимое четырехзначное число. </param>
		/// <param name="result"> Результат сравнения первых двух и оторбраженных последних двух цифр числа 
		/// (симметрии). </param>
		static void Check(int Number, out int result)
		{
			// Первые 2 цифры числа.
			int FirstTwoDigits = Number / 100;
			// Развернутые последние 2 цифры числа.
			int LastTwoDigits = (Number % 10) * 10 + (Number / 10) % 10;

			// Сравнение двух частей числа.
			result = FirstTwoDigits - LastTwoDigits + 1;
		}
		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную целочисленного типа
		/// с помощью метода TryParse, возвращает значение переменной и переменную булевого типа, показывающую,
		/// удалось ли преобразование (корректны ли входные данные).
		/// </summary>
		/// <param name="In"> Считываемая переменная. </param>
		/// <param name="ReadIn"> Переменная булевого типа, отражающая корректность вводных данных для считываемой 
		/// переменной. </param>
		static int Read(out bool ReadIn)
		{
			int In;
			ReadIn = int.TryParse(Console.ReadLine(), out In);
			return In;
		}
		/// <summary>
		/// Объявляется переменная - вводимое четырехзначное число, вызывается метод чтения с консоли
		/// если вводные данные некорректны(проверка с помощью условного оператора) (либо вводится не целое 
		/// число, либо не четырехзначное число), печатается строка wrong и программа завершает работу, иначе 
		/// вызывается метод проверки симметрии и выводятся выходные данные.
		/// </summary>
		static void Main(string[] args)
		{
			// Переменная - вводимое четырехзначное число.
			int Number;
			// Переменная типа bool для проверки правильности вводимых данных.
			bool ReadNumber;
			// Переменная для выводимого результата.
			int result;

			// Вызов метода чтения данных с консоли.
			Number = Read(out ReadNumber);

			// Проверка корректности вводимых данных + четырехзначности числа.
			if (!ReadNumber || Number < 1000 || Number > 9999)
			{
				// Вывод строки wrong и завершение работы программы.
				Console.WriteLine("wrong");
			}
			else
			{
				// Вызов метода проверки симметричности числа.
				Check(Number, out result);
				// Выходные данные.
				Console.WriteLine($"{result}");
			}
		}
	}
}

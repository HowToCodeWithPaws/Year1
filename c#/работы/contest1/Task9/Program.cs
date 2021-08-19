﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Дано натуральное число N. Выведите слово YES, если число N является точной степенью двойки, или слово NO 
//в противном случае.Операцией возведения в степень пользоваться нельзя!Выведите ответ на задачу(YES или NO).
//В случае, если входные данные не соответствуют условию, выведите строку wrong и сразу же завершите выполнение 
//программы.

namespace Task9
{
	class Program
	{
		/// <summary>
		/// Метод осуществляет проверку числа на соответствие степени двойки с помощью цикла while, вычисляющего
		/// степень двойки до тех пор, пока она не станет больше проверяемого числа. Далее присваивание результата
		/// переменной ответа с помощью тернарного оператора в зависимости от условия, является (result = YES) или
		/// нет (result = NO) число степенью двойки.
		/// </summary>
		/// <param name="Input"> Число, проверяемое на соответствие степени двойки. </param>
		/// <param name="result"> Переменная для ответа. </param>
		static void IsItTwoPower(uint Input, ref string result)
		{
			// Переменная для предыдущей степени двойки.
			uint n1 = 1;
			// Переменная для текущей степени двойки.
			uint TwoPower = 1;

			// Происходит рассчет степеней двойки без использования power до тех пор, пока степень не становится 
			// больше вводимого числа.
			while (TwoPower < Input)
			{
				TwoPower = n1 * 2;
				n1 = TwoPower;
			}

			// Присваивание с помощью тернарного оператора значения переменной ответа: если проверяемое число 
			// равно степени двойки, result = YES, иначе - NO
			result = (TwoPower == Input) ? "YES" : "NO";
		}
		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную целочисленного типа
		/// с помощью метода TryParse, возвращает значение переменной и переменную булевого типа, показывающую,
		/// удалось ли преобразование (корректны ли входные данные).
		/// </summary>
		/// <param name="In"> Считываемая переменная. </param>
		/// <param name="ReadIn"> Переменная булевого типа, отражающая корректность вводных данных для переменной. </param>
		static uint Read(out bool ReadIn)
		{
			uint In;
			ReadIn = uint.TryParse(Console.ReadLine(), out In);
			return In;
		}
		/// <summary>
		/// Объявляется переменная для вводимого числа, вызывается метод считывания, осуществляется проверка
		/// корректности вводимых данных (данные преобразуются в натуральное число) в в условном операторе с 
		/// помощью результатов работы метода TryParse, если данные некорректны, программа выводит строку
		/// wrong и завершает работу, иначе вызывает метод проверки числа на степень двойки, возвращающий новое
		/// значение переменной ответа, затем выводится ответ.
		/// </summary>
		static void Main(string[] args)
		{
			// Переменная целого беззнакового типа для вводимого числа.
			uint InputN;
			// Переменная булевого типа для проверки правильности вводимых данных.
			bool ReadN;
			// Переменная для ответа.
			string result = String.Empty;

			// Вызов метода чтения входных данных.
			InputN = Read(out ReadN);

			// Проверка корректности ввода данных (InputN должно быть целым числом и InputN>0).
			if (!ReadN || InputN < 1)
			{
				// Вывод строки wrong и завершение работы программы.
				Console.WriteLine("wrong");
			}
			else
			{
				// Вызов метода проверки, является ли число точной степенью двойки.
				IsItTwoPower(InputN, ref result);
				// Выходные данные.
				Console.WriteLine($"{result}");
			}
		}
	}
}

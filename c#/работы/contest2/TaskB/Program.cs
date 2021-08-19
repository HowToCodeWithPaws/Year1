﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Напишите программу, которая считывает значение основания произвольной системы счисления ∈[2;9], а затем целое неотрицательное число,
/// принадлежащее этой системе счисления, и переводит его в десятичную систему счисления.
/// Вводятся 2 числа – значение основания произвольной системы счисления ∈[2;9] и целое неотрицательное число в этой системе счисления.
/// В случае, если входные данные не соответствуют условию, выведите строку wrong и сразу же завершите выполнение программы. Выведите одно число 
/// – результат перевода в десятичную систему счисления.
/// При решении этой задачи необходимо учитывать, что пользователь может ввести число, не соответствующее введенной системе счисления. 
/// В таком случае, выведите строку wrong. Запрещается пользоваться строками и любыми коллекциями.

namespace TaskB
{
	class Program
	{
		/// <summary>
		/// Метод в цикле while проверят с помощью условного оператора if, подходит ли данное число к данной системе счисления, если нет - возвращает wrong, 
		/// иначе переводит данное число из данной системы счисления в десятичную систему счисления и возвращает новое число.
		/// </summary>
		/// <param name="nBase"> Переменная для основания системы счисления. </param>
		/// <param name="number"> Переменная для числа в данной системе счисления. </param>
		/// <returns> Метод возвращает натуральное число в десятичной системе счисления, если введенное число подходит под введенное основание системы счисления
		/// и wrong, если не подходит. </returns>

		static string ToDecimal(uint nBase, ulong number)
		{
			// Переменные для нового числа в десятичной системе счисления и для степени основания системы счисления для перевода.

			ulong decimalNumber = 0, n = 0;

			// Переменная для хранения последней цифры изначального числа.

			uint digit;

			// Проверка, подходит ли число к  системе счисления с введенным основанием.

			while (number > 0)
			{
				// Переменной присваивается остаток от деления изначального числа на 10, обновляющийся на каждой итерации.

				digit = (uint)number % 10;

				// Если каждая цифра числа меньше основания системы счисления, число переводится в десятичное, иначе выводится wrong и работа программы завершается.

				if (digit < nBase)
				{
					// Перевод осуществляется методом умножения цифры изначального числа на степень основания системы счисления и сложения этих произведений.

					number /= 10;
					decimalNumber += (uint)(digit * Math.Pow(nBase, n));
					n++;
				}
				else
				{
					return "wrong";
				}

			}

			return decimalNumber.ToString();
		}

		/// <summary>
		/// Метод принимает на вход и выводит через ref две переменные - основание системы счисления и число в этой системе счисления, вызывает для них методы
		/// считывания с консоли и осуществляет проверку верности вводимых данных: возвращает false, если параметры заданы неверно, и true в противном случае.
		/// </summary>
		/// <param name="nBase"> Переменная для основания системы счисления. </param>
		/// <param name="number"> Переменная для числа в этой системе счисления. </param>
		/// <returns> Метод возвращает булевое true или false в зависимости от верности вводимых данных для каждой переменной. </returns>

		static bool CheckInput(ref uint nBase, ref ulong number)
		{
			// Переменные булевого типа для проверки корректности вводимых данных.

			bool readN, readNumber;

			// Вызов метода чтения данных с консоли.

			nBase = ReadUint(out readN);

			// Проверка корректности данных: основание системы счисления целое и от 2 до 9.

			if (readN && nBase > 1 && nBase < 10)
			{
				// Вызов метода чтения данных с консоли.

				number = ReadUlong(out readNumber);

				// Проверка корректности данных: число целое и неотрицательное.

				if (readNumber && number >= 0)
				{
					// Если оба числа корректны - возвращается true, иначе - false.

					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}

		}

		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную целочисленного беззнакового типа
		/// с помощью метода TryParse, возвращает значение переменной и переменную булевого типа, показывающую,
		/// удалось ли преобразование (корректны ли входные данные).
		/// </summary>
		/// <param name="input"> Считываемая переменная. </param>
		/// <param name="readIn"> Переменная булевого типа, отражающая корректность вводных данных для переменной. </param>
	
		static uint ReadUint(out bool readIn)
		{
			uint input;
			readIn = uint.TryParse(Console.ReadLine(), out input);
			return input;
		}

		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную длинного беззнакового типа
		/// с помощью метода TryParse, возвращает значение переменной и переменную булевого типа, показывающую,
		/// удалось ли преобразование (корректны ли входные данные).
		/// </summary>
		/// <param name="input"> Считываемая переменная. </param>
		/// <param name="readIn"> Переменная булевого типа, отражающая корректность вводных данных для переменной. </param>

		static ulong ReadUlong(out bool readIn)
		{
			ulong input;
			readIn = ulong.TryParse(Console.ReadLine(), out input);
			return input;
		}

		/// <summary>
		/// Объявляются две переменные для основания системы счисления и числа в этой системе счисления, для них вызывается метод, считывающий их и проверяющий
		/// корректность вводимых данных, в зависимости от того, что он возвращает, программа либо выводит строку wrong и завершает работу (если данные 
		/// некорректны), либо, если данные верны (проверка условным оператором), вызывает метод перевода числа в десятичную систему счисления и выводит результат
		/// его работы.
		/// </summary>

		static void Main(string[] args)
		{
			// Переменные целого беззнакового типа для основания системы счисления и числа в этой системе счисления.

			uint countingBase = 0;
			ulong number = 0;

			// Вызов метода проверки корректности данных, вывод в зависимости от его результата.

			if (CheckInput(ref countingBase, ref number))
			{
				// Вызов метода перевода числа из данной системы счисления в десятичную, вывод нового числа.

				Console.WriteLine($"{ToDecimal(countingBase, number)}");
			}

			// Вывод строки wrong и завершение работы в случае некорректных данных.

			else
			{
				Console.WriteLine("wrong");
			}
		}
	}
}

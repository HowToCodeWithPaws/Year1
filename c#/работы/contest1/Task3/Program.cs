using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Дано число X. Требуется перевести это число в римскую систему счисления.
//Дано число X в десятичной системе счисления(1 ≤ X ≤ 100).
namespace Task3
{
	class Program
	{
		/// <summary>
		/// Метод получает на вход единицы числа в десятичной записи и методом switch case преобразует их в строку
		/// - римскую цифру, возвращает строку в точку вызова через ref.
		/// </summary>
		/// <param name="Input"> Единичный разряд в десятичной записи. </param>
		/// <param name="LastDigit"> Единичный разряд в римской записи. </param>
		static void LastDigitRoman(uint Input, ref string LastDigit)
		{
			switch (Input)
			{
				case 0:
					LastDigit = "";
					break;

				case 1:
					LastDigit = "I";
					break;

				case 2:
					LastDigit = "II";
					break;

				case 3:
					LastDigit = "III";
					break;

				case 4:
					LastDigit = "IV";
					break;

				case 5:
					LastDigit = "V";
					break;

				case 6:
					LastDigit = "VI";
					break;

				case 7:
					LastDigit = "VII";
					break;

				case 8:
					LastDigit = "VIII";
					break;

				case 9:
					LastDigit = "IX";
					break;
			}
		}
		/// <summary>
		/// Метод получает на вход десятки числа в десятичной записи и методом switch case преобразует их в строку
		/// - римскую цифру, возвращает строку в точку вызова через ref.
		/// </summary>
		/// <param name="Input"> Десятичный разряд в десятичной записи. </param>
		/// <param name="FirstDigit"> Десятичный разряд в римской записи. </param>
		static void FirstDigitRoman(uint Input, ref string FirstDigit)
		{
			switch (Input)
			{
				case 1:
					FirstDigit = "X";
					break;

				case 2:
					FirstDigit = "XX";
					break;

				case 3:
					FirstDigit = "XXX";
					break;

				case 4:
					FirstDigit = "XL";
					break;

				case 5:
					FirstDigit = "L";
					break;

				case 6:
					FirstDigit = "LX";
					break;

				case 7:
					FirstDigit = "LXX";
					break;

				case 8:
					FirstDigit = "LXXX";
					break;

				case 9:
					FirstDigit = "XC";
					break;
			}
		}
		/// <summary>
		/// Метод принимает число в десятичной записи и строку для вывода его римской записи (через ref), методом
		/// switch case проверяется величина числа: меньше 10, от 10 до 99 или 100, в зависимости от этого вызываются
		/// методы для преобразования числа в римску запись (для чисел меньше 10 это метод преобразования единичного 
		/// разряда, для чисел от 10 до 99 это методы преобразования единичного и десятичного разрядов, для 100
		/// строке ответа сразу присваивается С.
		/// </summary>
		/// <param name="Input"></param>
		/// <param name="NewForm"></param>
		static void Roman(uint Input, ref string NewForm)
		{
			// Проверка величины вводимого числа и применение разных методов в зависимости от этого.
			switch (Input < 10)
			{
				// Если число меньше 10, то его новая форма - это результат преобразования единичного разряда.
				case true:
					LastDigitRoman(Input, ref NewForm);
					break;

				// Если число больше 9, нужно сравнить его с 100.
				case false:
					// Сравнение числа с 100.
					switch (Input < 100)
					{
						// Если число меньше 100, его римская запись будет состоять из склеенных записей десятков 
						// и единиц.
						case true:
							// Десятичный разряд данного числа.
							uint FirstDigit = Input / 10;
							// Единичный разряд данного числа.
							uint LastDigit = Input % 10;
							// Римская запись десятичного разряда.
							string RomanFirstDigit = String.Empty;
							// Римсакя запись единичного разряда.
							string RomanLastDigit = String.Empty;

							// Вызов метода преобразования десятичного разряда в римскую запись.
							FirstDigitRoman(FirstDigit, ref RomanFirstDigit);
							// Вызов метода преобразования единичного разряда в римскую запись.
							LastDigitRoman(LastDigit, ref RomanLastDigit);

							// Строка ответа получается конкатенацией строк десятичного и единичного разрядов.
							NewForm = RomanFirstDigit + RomanLastDigit;
							break;

						// Если число = 100, его новая форма будет выглядеть как С.
						case false:
							NewForm = "C";
							break;
					}
					break;
			}
		}
		/// <summary>
		/// Метод считывает строку и пытается преобразовать ее переменную целочисленного беззнакового типа
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
		/// Объявляется переменная - считываемое число, которое надо записать римскими цифрами, вызывается метод
		/// чтения с консоли, выполняется проверка корректности вводимых данных(число от 1 до 100), если данные 
		/// неверны, программа выводит строку wrong и завершает работу, иначе вызывается метод, переводящий число 
		/// в римские цифры, возвращающий через ref новое значение переменной ответа, далее ответ выводится.
		/// </summary>
		static void Main(string[] args)
		{
			// Переменная - натуральное число от 1 до 100, которое надо записать римскими цифрами.
			uint DecimalToRoman;
			// Переменная типа bool для проверки правильности вводимых данных.
			bool ReadDec;
			// Переменная для выводимого результата.
			string result = String.Empty;

			// Вызов метода чтения данных с консоли.
			DecimalToRoman = Read(out ReadDec);

			// Проверка корректности вводимых данных.
			switch (!ReadDec || DecimalToRoman < 1 || DecimalToRoman > 100)
			{
				case true:
					// Вывод строки wrong и завершение работы программы.
					Console.WriteLine("wrong");
					break;

				case false:
					// Вызов метода перевода числа в римские цифры.
					Roman(DecimalToRoman, ref result);
					// Выходные данные.
					Console.WriteLine($"{result}");
					break;
			}
		}
	}
}


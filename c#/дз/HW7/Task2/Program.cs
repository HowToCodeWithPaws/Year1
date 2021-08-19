using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			HexNumber hex;      // ссылка с типом класса
			hex = new HexNumber(0); // объект класса
			uint number;
			while (true)
			{ // цикл для ввода разных значений числа 
				do Console.Write("Введите целое неотрицательное число:  ");
				while (!uint.TryParse(Console.ReadLine(), out number));

				hex.Number = number;     // Изменяем объект через свойство
				Console.WriteLine("Свойство Number: " + hex.Number);
				Console.Write("Шестнадцатеричные цифры числа: ");

				foreach (char h in hex.HexView) Console.Write("{0} ", h);

				Console.WriteLine($"{Environment.NewLine}Шестнадцатеричная запись: " + hex.Record);
				Console.WriteLine("Для выхода нажмите клавишу ESC");

				if (Console.ReadKey(true).Key == ConsoleKey.Escape) break;
			}    // while

		}
	}
}

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
			string[] lines = System.IO.File.ReadAllLines("..//..//magicData.txt");    // читаем все строки файла в массив
			int lineIndex = 0;  // на какой строке файла находимся
			int count = 0; // считаем, на каком мы сейчас квадрате
			while (lines.Length > lineIndex)
			{
				int size;   // размер квадрата
				if (!int.TryParse(lines[lineIndex], out size))
				{
					Console.WriteLine($"Ошибка при чтении размера квадрата: {lines[lineIndex]} - не число (строка {lineIndex + 1})");
					return;
				}
				if (size == -1)    // в конце файла ожидается -1
					return;
				lineIndex++;

				Square _square = new Square(size);

				_square.ReadSquare(lines, lineIndex);
				lineIndex += size;

				Console.WriteLine($"\n******** Квадрат номер {++count} ********");
				_square.PrintSquare();

				for (int i = 0; i < size; i++)
				{
					Console.WriteLine($"\nСумма элементов {i} строки равна: {_square.SumRow(i)}");
				}
				for (int i = 0; i < size; i++)
				{
					Console.WriteLine($"\nСумма элементов {i} столбца равна: {_square.SumCol(i)}");
				}
				Console.WriteLine($"\nСумма элементов главной диагонали равна: {_square.SumMainDiag()}");
				Console.WriteLine($"\nСумма элементов побочной диагонали равна: {_square.SumOtherDiag()}");

				if (_square.Magic())
				{
					Console.WriteLine("\nДанный квадрат является магическим. Вжух-вжух.");
				}
				else
				{
					Console.WriteLine("\nДанный квадрат не является магическим. *звуки грусти*.");
				}
				// TODO: определяем и выводим, является ли квадрат магическим
			}
		}

	}
}

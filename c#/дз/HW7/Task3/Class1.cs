using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	public class ConsolePlate
	{
		char _plateChar; // символ
		ConsoleColor _plateColor = ConsoleColor.White; // цвет символа
		ConsoleColor _backroundColor = ConsoleColor.Black;

		// конструкторы
		public ConsolePlate()
		{
			_plateChar = 'A';
		}

		public ConsolePlate(char plateChar, ConsoleColor plateColor) : this(plateChar, plateColor, ConsoleColor.Black) { }
		public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor backroundColor)
		{
			if (plateColor == backroundColor)
			{
				Console.WriteLine("\nНеправильное сочетание цвета фона и цвета символа");
				return;
			}

			this.PlateChar = plateChar; // используем свойства 
			this.PlateColor = plateColor;
			this._backroundColor = backroundColor;
		}
		// Объявление свойств 
		// свойства
		public char PlateChar
		{
			set
			{
				if (value > 64 && value < 91) // отбрасываем командные символы
					_plateChar = value;
				else
					_plateChar = 'A';
			}
			get { return _plateChar; }
		}
		public ConsoleColor PlateColor
		{
			set { _plateColor = value; }
			get { return _plateColor; }
		}

		public ConsoleColor Background
		{
			set { _backroundColor = value; }
			get
			{
				return _backroundColor;
			}
		}

	}

}

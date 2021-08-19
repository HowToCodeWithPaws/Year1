using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	public class HexNumber
	{   // представление неотрицательных целых
		uint number;            // целое неотрицательное число 
		char[] hexView;     // Шестнадцатеричное представление
		public HexNumber(uint n)
		{ // конструктор общего вида
			number = n;
			hexView = series(n);
		}

		// Возвращает массив шестнадцатеричных цифр числа-параметра. 
		char[] series(uint num)
		{
			int arLen = num == 0 ? 1 : (int)Math.Log(num, 16) + 1;
			char[] res = new char[arLen];
			for (int i = arLen - 1; i >= 0; i--)
			{
				uint temp = (uint)(num % 16);
				if (temp >= 0 & temp <= 9) res[i] = (char)('0' + temp);
				else res[i] = (char)('A' + temp % 10);
				num /= 16;
			}
			return res;
		}   // series


		public HexNumber() : this(0) { }
		public uint Number
		{   // Свойство: десятичное целое
			get { return number; }
			set
			{
				number = value;
				hexView = series(value);
			}
		}
		public char[] HexView
		{   // Свойство: массив символов-цифр
			get { return hexView; }
		}
		public string Record
		{   // Свойство: строковое представление (шестнадцатеричное) числа
			get
			{
				string str = new String(hexView);
				return "0x" + str;
			}
		}

	}   // HexNumber

}

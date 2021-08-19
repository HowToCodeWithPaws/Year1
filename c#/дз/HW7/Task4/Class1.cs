using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
	class MyClassmate
	{ // Одноклассник
		readonly string name = "Неизвестный"; // Фамилия
		readonly int birthYear = 1998; // год рождения
		const int apprenticeship = 4; // срок обучения (лет)
		static int entranceYear = 2016; // год поступления
		static MyClassmate()  // статический конструктор
		{
			entranceYear = 2015;
		}
		public MyClassmate() { } // Конструктор умолчания
		public MyClassmate(string name, int by)
		{   //Конструктор общего вида
			this.name = name;
			birthYear = by;
		}
		public string Information()
		{   // Метод объекта 
			return "Фамилия: " + name + "; возраст: " +
				(entranceYear - birthYear) +
				" лет; год окончания: " +
				(entranceYear + apprenticeship);
		}
	}

}

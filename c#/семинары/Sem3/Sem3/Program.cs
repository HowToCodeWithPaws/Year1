using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem3
{
	class Program
	{
		static string Score10ToScore4 (int score10)
		{
			switch (score10)
			{
				case var score when score >= 0 && score < 4:
					return "Неуд.";
				case 4:
				case 5:
					return "Уд.";
				case 6:
				case 7:
					return "Хор.";
				case var score when score >= 8 && score < 11:
					return "Отл.";
				default:
					throw new ArgumentException("Это не оценка");
			}
		}

//		static string Score10ToScore4(object obj)
//		{
//			switch (obj)
//			{
//				case double d when d == Math.PI:
//					return "Неуд.";
//				case List<Int16> list when list.Count > 0:
//				
//			}
	//	}
		static void Main(string[] args)
		{

			//		int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
			//	foreach (var item in arr) 
			for (int i = 0; i < 15; i++)
			{
				Console.WriteLine($"{i} в 10балльной шкале по четырехбалльной шкале равно {Score10ToScore4(i)}");
				//}
				//	Console.WriteLine("Введите вашу оценку");
			}
	}
	}
}


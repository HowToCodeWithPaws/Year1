using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BirdsLib.Utilities;

namespace BirdsLib
{
    public class Eagle:Bird
    {
		/// <summary>
		/// Конструктор с параметрами.
		/// </summary>
		/// <param name="name_"></param>
		/// <param name="maxDistance_"></param>
		public Eagle(string name_, int maxDistance_)
			: base(name_, maxDistance_)
		{
			isPredator = true;
		}

		/// <summary>
		/// Переопределенный метод полета.
		/// </summary>
		/// <returns></returns>
		public override int Move()
		{
			int distance = random.Next((int)(0.4 * MaxDistance), MaxDistance + 1);

			Console.WriteLine($"Eagle {Name} flied " +
				$"{distance} km");

			return distance;
		}

		/// <summary>
		/// Оверрайд метода ту стринг.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "Eagle." + base.ToString();
		}

	}
}

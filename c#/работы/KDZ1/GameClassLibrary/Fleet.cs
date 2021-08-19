using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClassLibrary
{
	/// <summary>
	/// Класс, представляющий собой флот,
	/// которым играет игрок.
	/// </summary>
	public class FleetArray
	{
		// Закрытые поля - массив кораблей,
		// выбрано ли грузовое судно, имя игрока.
		private Ship[] fleet = new Ship[5];
		private bool cargoPicked;
		private string playerName;

		/// <summary>
		/// Публичное свойство для поля fleet с 
		/// геттером.
		/// </summary>
		public Ship[] Fleet
		{
			get { return fleet; }
		}

		/// <summary>
		/// Публичное свойство для поля cargoPicked с 
		/// сеттером и геттером.
		/// </summary>
		public bool CargoPicked
		{
			get { return cargoPicked; }
			set { cargoPicked = value; }
		}

		/// <summary>
		/// Публичное свойство для поля playerName с 
		/// геттером.
		/// </summary>
		public string PlayerName
		{
			get { return playerName; }
		}

		/// <summary>
		/// Открытое свойство, возвращающее 
		/// количество кораблей в строю.
		/// </summary>
		public int NumberOfShipsAlive
		{
			get
			{
				int number = 0;
				foreach (Ship ship in Fleet)
				{
					if (ship.IsAlive())
					{
						number++;
					}
				}

				return number;
			}
		}

		/// <summary>
		/// Открытый конструктор, задающий поля имени,
		/// выбора грузового судна, а также каждый 
		/// элемент массива кораблей.
		/// </summary>
		/// <param name="_playerName"> Принимает имя игрока. </param>
		/// <param name="_cargoPicked"> Принимает выбрано ли 
		/// грузовое судно. </param>
		/// <param name="array"> Принимает массив кораблей. </param>
		public FleetArray(string _playerName, bool _cargoPicked,
			Ship[] array)
		{
			playerName = _playerName;

			CargoPicked = _cargoPicked;

			for (int i = 0; i < fleet.Length; i++)
			{
				fleet[i] = array[i];
			}
		}

		/// <summary>
		/// Открытый индексатор, возвращающий элемент 
		/// массива кораблей с заданным индексом.
		/// </summary>
		/// <param name="index"> Индекс. </param>
		/// <returns> Возвращает элемент массива 
		/// fleet через свойство. </returns>
		public Ship this[int index]
		{
			get { return Fleet[index]; }
		}

		/// <summary>
		/// Открытый метод, сообщающий, жив ли флот. Флот жив, 
		/// если жив хотя бы один боевой корабль.
		/// </summary>
		/// <returns></returns>
		public bool IsAlive()
		{
			foreach (Ship ship in Fleet)
			{
				if (!(ship is CargoShip) && ship.IsAlive())
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Открытый метод, позволяющий перенести припасы с 
		/// грузового судна на боевой корабль. Количество припасов
		/// на грузовом судне уменьшается на заданную величину, на
		/// корабле - увеличивается. Все изменения возвращаются как строки.
		/// </summary>
		/// <param name="ship"> Принимается корабль, на который 
		/// переносятся припасы. </param>
		/// <param name="numberOfCargo"> Принимается количество 
		/// переносимых припасов. </param>
		/// <returns> Возвращается строка с описанием результата 
		/// работы метода. </returns>
		public string TransferCargo(AttackingShip ship,
			int numberOfCargo)
		{
			(Fleet[CargoIndex()] as CargoShip).Cargo -= numberOfCargo;
			ship.Ammunition += numberOfCargo;

			return $"\nНа выбранный корабль перемещено {numberOfCargo}" +
				$" боеприпасов.\nНа грузовом судне осталось " +
				$"{(Fleet[CargoIndex()] as CargoShip).Cargo} груза.";
		}

		/// <summary>
		/// Открытый метод, находящий индекс грузового 
		/// судна в массиве. Метод будет всегда вызываться
		/// с проверкой того, есть ли в массиве грузовое 
		/// судно, поэтому внутри метода нет необходимости
		/// в проверке условия существования грузового судна.
		/// </summary>
		/// <returns> Возвращает индекс судна. </returns>
		public int CargoIndex()
		{
			for (int i = 0; i < 5; i++)
			{
				if (Fleet[i] is CargoShip)
				{
					return i;
				}
			}

			return 0;
		}

		/// <summary>
		/// Метод возвращает информацию о том, есть ли
		/// во флоте припасы. Во флоте есть припасы, если
		/// у живых боевых кораблей есть припасы или во флоте
		/// есть живое грузовое судно, на котором есть груз.
		/// </summary>
		/// <returns> Возвращает true, если припасы есть и 
		/// false иначе. </returns>
		public bool RemainingAmmo()
		{
			bool remainsAmmo = false;
			bool remainingOnCargo = false;

			foreach (Ship ship in Fleet)
			{
				if (!(ship is CargoShip) && ship.IsAlive() &&
					(ship as AttackingShip).Ammunition > 0)
				{
					remainsAmmo = true;
					break;
				}
			}

			if (CargoPicked)
			{
				remainingOnCargo = (Fleet[CargoIndex()] as CargoShip).IsAlive()
				&& (Fleet[CargoIndex()] as CargoShip).Cargo > 0;
			}

			return (remainsAmmo || remainingOnCargo);
		}

		/// <summary>
		/// Метод возвращает информацию, которую получает противник,
		/// когда атакует этот флот. С вероятностью 0,2 в выбор входит
		/// грузовой корабль при условии, что в флоте осталось 2 или
		/// менее живых кораблей, иначе номер грузового судна скрывается.
		/// </summary>
		/// <param name="number"> Скрываемый номер грузового судна. </param>
		/// <param name="conceal"> Переменная, показывающая надобность 
		/// сокрытия номера. </param>
		/// <returns> Метод возвращает информацию об элементах флота, 
		/// которые можно атаковать. </returns>
		public string GetAttackedInfo(out int number,
			out bool conceal)
		{
			number = 0;
			conceal = false;
			string returning = "";
			bool luck = Utilities.random.Next(1, 6) % 3 == 0;

			if ((CargoPicked && NumberOfShipsAlive <= 2 && luck)
				|| !CargoPicked)
			{
				returning = GetInfo();
			}
			else
			{
				returning = $"\n\n\t\t\t\t\t\t\t\t" +
					$"Информация о флоте {PlayerName}:\n";

				number = CargoIndex();
				conceal = true;

				for (int i = 0; i < 5; i++)
				{
					if (i != number)
					{
						returning += $"\n{i + 1}. "
							+ Fleet[i].GetInfo() + "\n";
					}
				}
			}

			return returning;
		}

		/// <summary>
		/// Метод возвращает информацию о 
		/// каждом корабле в флоте.
		/// </summary>
		/// <returns> Возвращает строку с информацией
		/// о флоте. </returns>
		public string GetInfo()
		{
			string returning = $"\n\n\t\t\t\t\t\t\t\t" +
				$"Информация о флоте {PlayerName}:\n";

			for (int i = 0; i < 5; i++)
			{
				returning += $"\n{i + 1}. "
					+ Fleet[i].GetInfo() + "\n";
			}

			return returning;
		}
	}
}
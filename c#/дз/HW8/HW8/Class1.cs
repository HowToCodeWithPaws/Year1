using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8
{
	public class IntegerList
	{
		private static readonly Random Random = new Random();

		private int[] _list;
		private uint numberOfEls = 0;

		public uint Number { get; private set; }

		/// <summary>
		/// Создаёт список указанного размера
		/// </summary>
		/// <param name="size">Размер списка</param>
		public IntegerList(int size)
		{
			_list = new int[size];
		}

		/// <summary>
		/// Заполняет список числами между 1 и 100 включительно
		/// </summary>
		public void Randomize()
		{
			for (int i = 0; i < _list.Length; i++)
			{
				_list[i] = Random.Next(101);

				numberOfEls += 1;
			}

		}

		public void AddElement(int newVal)
		{
			if (_list.Length == numberOfEls)
			{
				IncreaseSize(ref _list);
			}

			_list[numberOfEls] = newVal;
			numberOfEls += 1;
		}

		public void IncreaseSize(ref int[] _list)
		{
			int[] new_list = new int[2 * _list.Length];
			for (int i = 0; i < numberOfEls; i++)
			{
				new_list[i] = _list[i];
			}

			_list = new_list;
		}

		public void RemoveFirst(int val)
		{
			for (int i = 0; i < numberOfEls; i++)
			{
				if (_list[i] == val)
				{
					for (int j = i; j < numberOfEls; j++)
					{
						_list[j] = _list[j + 1];
					}
					numberOfEls -= 1;
					break;
				}
			}
		}

		public void RemoveAll(int val)
		{
			for (int i = 0; i < numberOfEls; i++)
			{
				if (_list[i] == val)
				{
					for (int j = i; j < numberOfEls; j++)
					{
						_list[j] = _list[j + 1];
					}
					numberOfEls -= 1;
				}
			}

			for (int i = 0; i < numberOfEls; i++)
			{
				if (_list[i] == val)
				{
					_list[i] = _list[i + 1];
					numberOfEls -= 1;
				}
			}
		}

		/// <summary>
		/// Печатает элементы списка с их индексами
		/// </summary>
		public void Print()
		{
			Console.WriteLine("\nВаш список:");
			for (int i = 0; i < numberOfEls; i++)
				Console.WriteLine(i + ":\t" + _list[i]);
		}
	}
}

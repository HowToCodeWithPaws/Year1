using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem8
{
	class Item
	{
		public string Name { get; }
		public double Price { get; }
		public int Quantity { get; }

		public Item(string itemName, double itemPrice, int numPurchased)
		{
			Name = itemName;
			Price = itemPrice;
			Quantity = numPurchased;
		}

		public override string ToString()
		{
			return $"Товар: {Name}\t\t Цена: {Price:C}\t\t Количество: {Quantity} шт.\t\t Стоимость: {Price * Quantity:C}";
		}
	}
}

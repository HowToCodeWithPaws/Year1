using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem8
{
	class ShoppingCart
	{
		public int _itemCount;
		public double _totalPrice { get; private set; }
		public int _capacity { get; private set; }
		private Item[] _cart;

		public ShoppingCart()
		{
			_capacity = 5;
			_itemCount = 0;
			_totalPrice = 0.0;
			_cart = new Item[_capacity];
		}

		public void AddToCart(string itemName, double price, int quantity)
		{
			Item itemToAdd = new Item(itemName, price, quantity);
			AddToCart(itemToAdd);
		}

		public void AddToCart(Item item)
		{
			if (_capacity == _cart.Length)
			{
				IncreaseSize();
			}
			_cart[_itemCount++] = item;
			_totalPrice += item.Price * item.Quantity;
		}

		private void IncreaseSize()
		{
			Array.Resize(ref _cart, _cart.Length + 3);
		}

		public string this[int i]
		{
			get
			{
				if (i >= 0 && i < _itemCount)
					return _cart[i].ToString();
				else throw new IndexOutOfRangeException();
			}
		}

		public override string ToString()
		{
			string contents = "\nShopping Cart\n";
			contents += "\nItem\t\tUnit Price\tQuantity\tTotal\n";
			for (int i = 0; i < _itemCount; i++)
			{
				contents += _cart[i] + "\n";
			}

			contents += $"\nTotal Price: {_totalPrice:C}\n";

			return contents;
		}
	}
}

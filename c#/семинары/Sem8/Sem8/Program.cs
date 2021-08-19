using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Inter-class objects relations
// 1 Association: they are connected but exist independently
// 2 Composition: one is created inside of the other, the one on the inside ceases with the outer one
// 3 Aggregation: one is created outside of the other before the other, and then added as a part of the bigger one
// the inner doesn't cease with the outer but the outer can't exist without the inner
namespace Sem8
{
	class Program
	{
		public static int ReadInt(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
		{
			int input;

			do
			{
				Console.Write(message);
			} while (!int.TryParse(Console.ReadLine(), out input) || input > maxValue || input < minValue);

			return input;
		}

		public static double ReadDouble(string message, double minValue = double.MinValue, int maxValue = int.MaxValue)
		{
			double input;

			do
			{
				Console.Write(message);
			} while (!double.TryParse(Console.ReadLine(), out input) || input > maxValue || input < minValue);

			return input;
		}

		static void Main(string[] args)
		{
			do
			{
				ShoppingCart shoppingCart = new ShoppingCart();
				do
				{
					Console.Write("\nВведите название товара: ");
					string itemName = Console.ReadLine();
					double price = ReadDouble("Введите цену: ", 0);
					int quantity = ReadInt("Введите количество единиц товара: ", 1);

					Item item = new Item(itemName, price, quantity);
					shoppingCart.AddToCart(item.Name, item.Price, item.Quantity);

					Console.WriteLine("\nЕсли хотите прододжить покупки, нажмите Enter, иначе нажмите любую другую клавишу");
				} while (Console.ReadKey().Key == ConsoleKey.Enter);

				Console.WriteLine($"\nОбщая стоимость товаров: {shoppingCart._totalPrice}");
				Console.WriteLine("Список товаров");
				for(int i=0; i < shoppingCart._itemCount;++i)
				{
					Console.WriteLine(shoppingCart[i]);
				}

				Console.WriteLine("\nДля повторного решения нажмите Enter, для выхода нажмите любой другой символ");

			} while (Console.ReadKey().Key == ConsoleKey.Enter);
		}
	}
}

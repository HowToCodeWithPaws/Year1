using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EKRLib
{
	public class Item : IComparable<Item>
	{
		double weight;

		public double Weight { get => weight; }

		public Item(double weight)
		{
			if (weight < 0)
			{
				throw new ItemsException("negative weight is prohibited");
			}

			this.weight = weight;
		}

		public override string ToString() => $"Weight: {Weight:F3}";

		public static explicit operator Double(Item item) => item.Weight;

		public int CompareTo(Item other) => this.Weight.CompareTo(other.Weight);
	}
}

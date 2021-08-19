using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{//Collections: List, Queue, Dequeue, Stack, Set, Dictionary

	class Card
	{
		private string number;

		private const int CARD_NUM_SIZE = 16;
		public string MaskedNumber { get => $"**{number.Substring(number.Length - 4)}"; }

		public Card(string number_)
		{
			number = number_.Replace(" ", string.Empty);
			if (number.Length != CARD_NUM_SIZE)
			{
				throw new ArgumentException();
			}
		}

		public override string ToString()
		{
			return MaskedNumber;
		}

		public override bool Equals(object obj)
		{
			return obj is Card card &&
				   number == card.number &&
				   MaskedNumber == card.MaskedNumber;
		}

		public override int GetHashCode()
		{
			var hashCode = 1186989745;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(number);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MaskedNumber);
			return hashCode;
		}
	}


	class Program
	{
		static void Main(string[] args)
		{

			HashSet<Card> cards = new HashSet<Card>();
			cards.Add(new Card("1111 2222 3333 4444"));
			cards.Add(new Card("1111 2222 3435 4564"));
			cards.Add(new Card("1111 2222 3333 4444"));

			foreach (Card card in cards)
			{
				Console.WriteLine(card);
			}
		}
	}
}

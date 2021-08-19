using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sem25
{
	static class Extension
	{
		static readonly Random random = new Random();

		public static IEnumerable<T> HalfExchange<T>(this IEnumerable<T> firstHalf, IEnumerable<T> secondHalf)
		{

			var firstIterator = firstHalf.GetEnumerator();
			var secondIterator = secondHalf.GetEnumerator();

			while (firstIterator.MoveNext() && secondIterator.MoveNext())
			{
				yield return firstIterator.Current;
				yield return secondIterator.Current;
			}

			//while (firstIterator.MoveNext()) {

			//	yield return firstIterator.Current;
			//}


			//while (secondIterator.MoveNext())
			//{

			//	yield return secondIterator.Current;
			//}
		}

		public static IEnumerable<T> FaroShuffle<T>(this IEnumerable<T> deck)
		{

			var deckSize = deck.Count();

			var shuffle = deck;

			for (int i = 0; i < 7; i++)
			{
				var deckIndex = random.Next(deck.Count());
				var firstHalf = deck.Take(deckIndex);
				var secondHalf = deck.Skip(deckIndex);
				shuffle = firstHalf.HalfExchange(secondHalf);
			}

			shuffle = shuffle.Union(deck).Distinct();

			return shuffle;
		}
	}
	class Program
	{


		static IEnumerable<string> Suits()
		{
			yield return "Черви";
			yield return "Буби";
			yield return "Пики";
			yield return "Крести";
		}



		static IEnumerable<string> Ranks()
		{
			yield return "2";
			yield return "3";
			yield return "4";
			yield return "5";
			yield return "6";
			yield return "7";
			yield return "8";
			yield return "9";
			yield return "10";
			yield return "Валет";
			yield return "Дама";
			yield return "Король";
			yield return "Туз";
		}

		static IEnumerable<T> HalfExchange<T>(IEnumerable<T> firstHalf, IEnumerable<T> secondHalf)
		{

			var firstIterator = firstHalf.GetEnumerator();
			var secondIterator = secondHalf.GetEnumerator();

			while (firstIterator.MoveNext() && secondIterator.MoveNext())
			{
				yield return firstIterator.Current;
				yield return secondIterator.Current;
			}
		}

		public class Player
		{

			public string Name { get; }
			public IEnumerable<string> cardIds { get; }
			public string CardId { get; }
			public string CardId2 { get; }


			public Player(string name, string cardid1, string cardid2)
			{
				Name = name;

				cardIds = new string[] { cardid1, cardid2 };
				CardId = cardid1;
				CardId2 = cardid2;
			}

			public override string ToString()
			{
				return $"Name {Name} with cardId {CardId}, cardId2 {CardId2}";
			}
		}

		static void Main(string[] args)
		{
			//	var index = 0;
			var deck = from suit in Suits()
					   from rank in Ranks()
					   select new
					   {
						   Indx = Ranks().Count() * Suits().ToList().IndexOf(suit) +
					   Ranks().ToList().IndexOf(rank),
						   Suit = suit,
						   Rank = rank
					   };

			foreach (var card in deck)
			{
				Console.WriteLine(card);
			}

			Console.WriteLine("shufflinnn");


			foreach (var card in deck.FaroShuffle())
			{
				Console.WriteLine(card);
			}

			var players = new Player[] {
			new Player("John", "32", "43"),
			new Player("Jade", "3", "4")
			};

			var playerCards = from player in players
							  join card in deck on player.CardId equals card.Indx.ToString()
							  join card2 in deck on player.CardId2 equals card2.Indx.ToString()
							  select new { Player = player.Name, Card = card, Card2 = card2 };

			foreach (var player in playerCards)
			{
				Console.WriteLine(player);
			}
		}
	}
}

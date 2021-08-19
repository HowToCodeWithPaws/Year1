using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somethingPeculiar
{
	public delegate void EventHappened();
	public class Publisher
	{
		public event EventHappened somethingHappened;

		public void fireEvent()
		{
			Console.WriteLine("Fire somethingHappened!!!");
			somethingHappened();
		}
	}


	public class SomethingHappenedSubscriber
	{
		public void SomethingHappenedHandler()
		{
			Console.WriteLine("Subscriber has handled an event!");
		}

		public void AnotherHandler()
		{
			Console.WriteLine("Another handler worked!");
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			Publisher pub = new Publisher();

			SomethingHappenedSubscriber shs = new SomethingHappenedSubscriber();

			pub.somethingHappened += shs.SomethingHappenedHandler;

			SomethingHappenedSubscriber shs2 = new SomethingHappenedSubscriber();

			pub.somethingHappened += shs2.AnotherHandler;

			pub.fireEvent();
		}
	}
}

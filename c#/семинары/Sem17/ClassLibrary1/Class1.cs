using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
	public delegate void CarEngineHandler(string msgForCaller);

	public class Car
	{
		public int CurrentSpeed { get; set; }
		public int MaxSpeed { get; set; }
		public string PetName { get; set; }
		private bool IsCarDead;
		public Car() { MaxSpeed = 100; }
		public Car(string name, int maxSp, int currSp)
		{
			CurrentSpeed = currSp;
			MaxSpeed = maxSp;
			PetName = name;
		}

		private CarEngineHandler listOfHandlers;

		public void RegisterWithCarEngine(CarEngineHandler methodToCall)
		{
			listOfHandlers = methodToCall;
		}

		public void Accelerate(int delta)
		{
			if (IsCarDead)
			{
				if (listOfHandlers != null) listOfHandlers("Sorry, the car is broken juct like all of us");
			}
			else
			{
				CurrentSpeed += delta;

				if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
				{
					listOfHandlers("Warning! Be more careful");
				}
				if (CurrentSpeed >= MaxSpeed)
				{
					IsCarDead = true;
				}
				else { listOfHandlers($"Current speed is {CurrentSpeed}"); }
			}
		}
	}
}

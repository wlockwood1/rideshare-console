using System;
namespace TransportProj
{
	public class SedanFactory : ICarFactory
	{
		public Car CreateCar(int xPos, int yPos, City city, Passenger passenger)
		{
			return new Sedan(xPos, yPos, city, passenger);
		}

	}
}

using System;
namespace TransportProj
{
	public class SedanFactory : ICarFactory
	{
		public override ICar CreateCar(int xPos, int yPos, City city, Passenger passenger)
		{
			return new Sedan(xPos, yPos, city, passenger);
		}

	}
}

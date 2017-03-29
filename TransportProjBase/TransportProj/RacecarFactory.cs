using System;
namespace TransportProj
{
	public class RacecarFactory : ICarFactory
	{
		public override ICar CreateCar(int xPos, int yPos, City city, Passenger passenger)
		{
			return new Racecar(xPos, yPos, city, passenger);
		}
	}
}

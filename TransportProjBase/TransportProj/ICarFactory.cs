using System;
namespace TransportProj
{
	public abstract class ICarFactory
	{
		public abstract ICar CreateCar(int xPos, int yPos, City city, Passenger passenger);
	}
}

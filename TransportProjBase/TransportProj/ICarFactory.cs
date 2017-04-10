using System;
namespace TransportProj
{
	public interface ICarFactory
	{
		Car CreateCar(int xPos, int yPos, City city, Passenger passenger);
	}
}

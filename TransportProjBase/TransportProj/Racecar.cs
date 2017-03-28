using System;

namespace TransportProj
{
    public class Racecar : IRaceCar
    {

		public Racecar(int xPos, int yPos, City city, Passenger passenger)
		{
			XPos = xPos;
			YPos = yPos;
			City = city;
			Passenger = passenger;
		}

    }
}

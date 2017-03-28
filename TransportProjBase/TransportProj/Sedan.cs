using System;

namespace TransportProj
{
    public class Sedan : ISedan
    {
        public Sedan(int xPos, int yPos, City city, Passenger passenger)
        {
			XPos = xPos;
			YPos = yPos;
			City = city;
			Passenger = passenger;
        }

    }
}

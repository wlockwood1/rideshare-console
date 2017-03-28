using System;

namespace TransportProj
{
    public abstract class ICar
    {
		public int XPos { get; protected set; }
		public int YPos { get; protected set; }
		public Passenger Passenger { get; protected set; }
		public City City { get; protected set; }

		public abstract void MoveUp(int destYPos);
		public abstract void MoveDown(int destYPos);
		public abstract void MoveRight(int destXPos);
		public abstract void MoveLeft(int destXPos);
		public abstract void WritePositionToConsole();

		public void PickupPassenger(Passenger passenger)
		{
			Passenger = passenger;
		}
    }

}

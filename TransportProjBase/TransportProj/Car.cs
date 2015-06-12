using System;

namespace TransportProj
{
    public abstract class Car
    {
        public int XPos { get; protected set; }
        public int YPos { get; protected set; }
        public Passenger Passenger { get; private set; }
        public City City { get; private set; }

        public Car(int xPos, int yPos, City city, Passenger passenger)
        {
            XPos = xPos;
            YPos = yPos;
            City = city;
            Passenger = passenger;
        }

        protected void WritePositionToConsole()
        {
            Console.WriteLine(String.Format("Car moved to x - {0} y - {1}", XPos, YPos));
        }

        public void PickupPassenger(Passenger passenger)
        {
            Passenger = passenger;
        }

        public abstract void MoveUp();

        public abstract void MoveDown();

        public abstract void MoveRight();

        public abstract void MoveLeft();
    }
}

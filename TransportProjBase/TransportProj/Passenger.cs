using System;

namespace TransportProj
{
    public class Passenger
    {
        public int StartingXPos { get; private set; }
        public int StartingYPos { get; private set; }
        public int DestinationXPos { get; private set; }
        public int DestinationYPos { get; private set; }
        public ICar Car { get; set; }
        public City City { get; private set; }

        public Passenger(int startXPos, int startYPos, int destXPos, int destYPos, City city)
        {
            StartingXPos = startXPos;
            StartingYPos = startYPos;
            DestinationXPos = destXPos;
            DestinationYPos = destYPos;
            City = city;
        }

        public void GetInCar(ICar car)
        {
            Car = car;
            car.PickupPassenger(this);
            Console.WriteLine("Passenger got in car.");
        }

        public void GetOutOfCar()
        {
            Car = null;
        }

        public int GetCurrentXPos()
        {
            if(Car == null)
            {
                return StartingXPos;
            }
            else
            {
                return Car.XPos;
            }
        }

        public int GetCurrentYPos()
        {
            if (Car == null)
            {
                return StartingYPos;
            }
            else
            {
                return Car.YPos;
            }
        }

        public bool IsAtDestination()
        {
            return GetCurrentXPos() == DestinationXPos && GetCurrentYPos() == DestinationYPos;
        }
    }
}

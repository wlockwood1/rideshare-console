
namespace TransportProj
{
    public class City
    {
        public static int YMax { get; private set; }
        public static int XMax { get; private set; }

        public City(int xMax, int yMax)
        {
            XMax = xMax;
            YMax = yMax;
        }

        public Car AddCarToCity(int xPos, int yPos)
        {
            Sedan car = new Sedan(xPos, yPos, this, null);

            return car;
        }
        
        public Car AddRacecarToCity(int xPos, int yPos)
        {
            Racecar car = new Racecar(xPos, yPos, this, null);

            return car;
        }

        public Passenger AddPassengerToCity(int startXPos, int startYPos, int destXPos, int destYPos)
        {
            Passenger passenger = new Passenger(startXPos, startYPos, destXPos, destYPos, this);

            return passenger;
        }

    }
}

using System;

namespace TransportProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int CityLength = 10;
            int CityWidth = 10;

            City MyCity = new City(CityLength, CityWidth);
            Car car = MyCity.AddCarToCity(rand.Next(CityLength - 1), rand.Next(CityWidth - 1));
            Passenger passenger = MyCity.AddPassengerToCity(rand.Next(CityLength - 1), rand.Next(CityWidth - 1), rand.Next(CityLength - 1), rand.Next(CityWidth - 1));

            while(!passenger.IsAtDestination())
            {
                Tick(car, passenger);
            }

            return;
        }

        /// <summary>
        /// Takes one action (move the car one spot or pick up the passenger).
        /// </summary>
        /// <param name="car"></param>
        /// <param name="passenger"></param>
        private static void Tick(Car car, Passenger passenger)
        {
            
        }

    }
}

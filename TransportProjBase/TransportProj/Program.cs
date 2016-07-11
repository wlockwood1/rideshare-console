using System;
using System.Collections.Generic;

namespace TransportProj
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rand = new Random();
            const int cityLength = 10;
            const int cityWidth = 10;

            var city = new City(cityLength, cityWidth);
            var car = city.AddCarToCity(rand.Next(cityLength - 1), rand.Next(cityWidth - 1));
            var passenger = city.AddPassengerToCity(rand.Next(cityLength - 1), rand.Next(cityWidth - 1), rand.Next(cityLength - 1), rand.Next(cityWidth - 1));

            // TODO -- REQUIRED: instantiate an appropriate data structure that can be used to store Coordinates. 
            // Ensure the data structure you pick will allow for a time efficient solution.
            ICollection<Coordinate> visitedCoordinates = null; 
            while(!passenger.IsAtDestination())
            {
                var currentCoordinate = Tick(car, passenger);
                VisitCoordinate(currentCoordinate, visitedCoordinates);
            }

            PrintVisitedCoordinates(visitedCoordinates);
        }

        /// <summary>
        /// Takes one action (move the car one spot or pick up the passenger).
        /// </summary>
        /// <param name="car">The car to move</param>
        /// <param name="passenger">The passenger to pick up</param>
        /// <returns>A Coordinate representing the location of the Car after the move was made</returns>
        private static Coordinate Tick(Car car, Passenger passenger)
        {
            // TODO -- REQUIRED: fill this method in.

            // TODO -- REQUIRED: Leave a comment at the end of the method explaining what the time complexity of this method is (using Big O notation).
            return null;
        }

        /// <summary>
        /// Visits a coordinate by adding it to the visitedCoordinates collection.
        /// </summary>
        /// <param name="coordinate">the coordinate to visit</param>
        /// <param name="visitedCoordinates">the collection of coordinates that were already visited</param>
        private static void VisitCoordinate(Coordinate coordinate, ICollection<Coordinate> visitedCoordinates) 
        {
            // TODO -- REQUIRED: fill this method in.

            // TODO -- REQUIRED: Leave a comment at the end of the method explaining what the time complexity of this method is (using Big O notation).
        }

        /// <summary>
        /// Prints all the coordinates that were visited and the number of times each coordinate was visited to the Console.
        /// For example, if the coordinate (1, 1) was visited once and the Coordinate (1, 2) was visited twice, the output should be as follows:
        /// 
        /// Visited coordinates:
        /// (1, 1) - 1
        /// (1, 2) - 2
        /// 
        /// </summary>
        /// <param name="visitedCoordinates">The collection of coordinates that were visited</param>
        private static void PrintVisitedCoordinates(IEnumerable<Coordinate> visitedCoordinates)
        {
            // TODO -- REQUIRED: fill this method in.

            // TODO -- REQUIRED: Leave a comment at the end of the method explaining what the time complexity of this method is (using Big O notation).
        }
    }
}

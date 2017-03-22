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
            var car = city.AddRacecarToCity(rand.Next(cityLength - 1), rand.Next(cityWidth - 1));
            var passenger = city.AddPassengerToCity(rand.Next(cityLength - 1), rand.Next(cityWidth - 1), rand.Next(cityLength - 1), rand.Next(cityWidth - 1));

            Console.WriteLine("Car is starting at coordinate ({0}, {1})", car.XPos, car.YPos);            
            Console.WriteLine("Passenger pickup is at coordinate ({0}, {1})", passenger.StartingXPos, passenger.StartingYPos);
            Console.WriteLine("Passenger destination is at coordinate ({0}, {1})", passenger.DestinationXPos, passenger.DestinationYPos);
            
            // TODO -- REQUIRED: instantiate an appropriate data structure that can be used to store Coordinates. 
            // Ensure the data structure you pick will allow for a time efficient solution.
            IDictionary<Coordinate, int> visitedCoordinates = new Dictionary<Coordinate, int>();
                       
            while(!passenger.IsAtDestination())
            {
                var currentCoordinate = Tick(car, passenger);
                VisitCoordinate(currentCoordinate, visitedCoordinates);
            }

            passenger.GetOutOfCar();
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
            int carXPos = car.XPos;
            int carYPos = car.YPos;
            //Car destination coordinate will either be to pickup passenger if we haven't yet or to the passenger destination if we have
            int carDestXPos = passenger.Car == null ? passenger.GetCurrentXPos() : passenger.DestinationXPos;
            int carDestYPos = passenger.Car == null ? passenger.GetCurrentYPos() : passenger.DestinationYPos;
			//If passenger isn't in car,check if we are destination to pick up passenger
            if (carXPos == carDestXPos && carYPos == carDestYPos)
            {
                passenger.GetInCar(car);
            }
            else {
                //Check if we're at same x position as destination
                if (carXPos != carDestXPos)
                {
                    //Check if we are east or west of destination
                    if (carXPos > carDestXPos) {
                        car.MoveLeft(carDestXPos);
                    } else {
                        car.MoveRight(carDestXPos);
                    }
                } else {
                    //We are at same x position, see if we are north or south of passenger
                    if (carYPos > carDestYPos)  {
                        car.MoveDown(carDestYPos);
                    } else {
                        car.MoveUp(carDestYPos);
                    }
                }
            }
            // TODO -- REQUIRED: fill this method in.
            //should return new coordinate
            var coordinate = new Coordinate(car.XPos, car.YPos);
            return coordinate;
        }

        /// <summary>
        /// Visits a coordinate by adding it to the visitedCoordinates collection.
        /// </summary>
        /// <param name="coordinate">the coordinate to visit</param>
        /// <param name="visitedCoordinates">the collection of coordinates that were already visited</param>
        private static void VisitCoordinate(Coordinate coordinate, IDictionary<Coordinate, int> visitedCoordinates) 
        {
            // TODO -- REQUIRED: fill this method in.
            //Check if coordinate is in there already
            // if {
            if (visitedCoordinates.ContainsKey(coordinate)) {
                //Increment number of times we've visited coordinate if it's already in dictionary
                visitedCoordinates[coordinate]++;
                // Console.WriteLine ("Have visited ({0}, {1}) a total of {2} times", coordinate.XPos, coordinate.YPos, visitedCoordinates[coordinate]);
            } else {
                //Add coordinate with value of 1 to indicate we've visited once
                // Console.WriteLine ("Adding ({0}, {1}) to visited coordinates", coordinate.XPos, coordinate.YPos);
                visitedCoordinates.Add(coordinate, 1);
            }

            // TODO -- REQUIRED: Leave a comment at the end of the method explaining what the time complexity of this method is (using Big O notation).
            // Time complexity of method is O(1) - Dictionary.Add and Dictionary.ContainsKey methods are both O(1) operations
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
        private static void PrintVisitedCoordinates(IDictionary<Coordinate, int> visitedCoordinates)
        {
            // TODO -- REQUIRED: fill this method in.
            Console.WriteLine("Visited coordinates: ");
            //Print each coordinate and number of times we've visited it
            foreach (KeyValuePair<Coordinate, int> coord in visitedCoordinates)
            {
                Console.WriteLine("({0}, {1}) - {2}", coord.Key.XPos, coord.Key.YPos, coord.Value);
            }
            // TODO -- REQUIRED: Leave a comment at the end of the method explaining what the time complexity of this method is (using Big O notation).
            // Complexity is O(n), since we are iterating through each of the key/value pairs in the dictionary and printing out the key and value            
        }
    }
}

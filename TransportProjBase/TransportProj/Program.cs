using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace TransportProj
{
    internal class Program
    {
		private static UnityContainer _container;
        private static void Main(string[] args)
        {
			_container = new UnityContainer();

			//Register factory mappings based on user input
			_container.RegisterType<ICarFactory, SedanFactory>("sedan");
			_container.RegisterType<ICarFactory, RacecarFactory>("racecar");

			//Register default factory
			_container.RegisterType<ICarFactory, SedanFactory>();

           	var rand = new Random();
            const int cityLength = 10;
            const int cityWidth = 10;

            var city = new City(cityLength, cityWidth);
            var passenger = city.AddPassengerToCity(rand.Next(cityLength - 1), rand.Next(cityWidth - 1), rand.Next(cityLength - 1), rand.Next(cityWidth - 1));

			//Ask user what type of car they want
			Console.WriteLine("Please enter which type of car you'd like to use (enter sedan or racecar):");
			string carType = Console.ReadLine().Trim().ToLower();

			//Get factory and create car based on what user asked for
			var factory = GetFactory(carType);
			ICar car = factory.CreateCar(rand.Next(cityLength - 1), rand.Next(cityWidth - 1), city, null);

            //Console.WriteLine("Car is starting at coordinate ({0}, {1})", car.XPos, car.YPos);            
            //Console.WriteLine("Passenger pickup is at coordinate ({0}, {1})", passenger.StartingXPos, passenger.StartingYPos);
            //Console.WriteLine("Passenger destination is at coordinate ({0}, {1})", passenger.DestinationXPos, passenger.DestinationYPos);
            
            // TODO -- REQUIRED: instantiate an appropriate data structure that can be used to store Coordinates. 
            // Ensure the data structure you pick will allow for a time efficient solution.
            IDictionary<Coordinate, int> visitedCoordinates = new Dictionary<Coordinate, int>(cityLength * cityWidth);
                       
            while(!passenger.IsAtDestination())
            {
                var currentCoordinate = Tick(car, passenger);
                VisitCoordinate(currentCoordinate, visitedCoordinates);
            }

            passenger.GetOutOfCar();
            PrintVisitedCoordinates(visitedCoordinates);
        }

		/// <summary>
		/// Gets the car factory to use based on what type of car user requested
		/// </summary>
		/// <param name="carType">The car type requested by user</param>
		/// <returns>Concrete instance of the ICarFactory registered based on the user input</returns>
		private static ICarFactory GetFactory(string carType)
		{
			if (_container.IsRegistered<ICarFactory>(carType))
			{
				return _container.Resolve<ICarFactory>(carType);
			}
			return _container.Resolve<ICarFactory>();
		}

        /// <summary>
        /// Takes one action (move the car one spot or pick up the passenger).
        /// </summary>
        /// <param name="car">The car to move</param>
        /// <param name="passenger">The passenger to pick up</param>
        /// <returns>A Coordinate representing the location of the Car after the move was made</returns>
        private static Coordinate Tick(ICar car, Passenger passenger)
        {
            int carXPos = car.XPos;
            int carYPos = car.YPos;
            //Car destination coordinate will either be to pickup passenger if we haven't yet or to the passenger destination if we have
            int carDestXPos = passenger.Car == null ? passenger.GetCurrentXPos() : passenger.DestinationXPos;
            int carDestYPos = passenger.Car == null ? passenger.GetCurrentYPos() : passenger.DestinationYPos;
			//If passenger isn't in car,check if we are at destination to pick up passenger
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
            //Check if coordinate is in dictionary already
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
            // Time complexity of method is O(1) - ContainsKey retrieves by using its key is fast because Dictionary class is implemented as a hash table
			// Dictionary.Add is also O(1) as long as the count is less than the capacity, and since we are setting the capacity to the product of the city length and city width, the count will never be higher than the capacity
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
			// Complexity is O(n), (with n being the number of key/value pairs in the dictionary), since we are iterating through each of the key/value pairs in the dictionary and printing out the key and value            
        }
    }
}

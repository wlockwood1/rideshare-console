﻿using System;

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

        protected virtual void WritePositionToConsole()
        {
            Console.WriteLine($"Car moved to x - {XPos} y - {YPos}");
        }

        public void PickupPassenger(Passenger passenger)
        {
            Passenger = passenger;
        }

        public abstract void MoveUp(int yPos);

        public abstract void MoveDown(int yPos);

        public abstract void MoveRight(int xPos);

        public abstract void MoveLeft(int xPos);
    }
}

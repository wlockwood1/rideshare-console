using System;

namespace TransportProj
{
    public class Sedan : Car
    {
        public Sedan(int xPos, int yPos, City city, Passenger passenger) : base(xPos, yPos, city, passenger)
        {
        }

        public override void MoveUp(int carYPos)
        {
            if (YPos < City.YMax)
            {
                YPos++;
                WritePositionToConsole();
            }
        }

        public override void MoveDown(int carYPos)
        {
            if (YPos > 0)
            {
                YPos--;
                WritePositionToConsole();
            }
        }

        public override void MoveRight(int carXPos)
        {
            if (XPos < City.XMax)
            {
                XPos++;
                WritePositionToConsole();
            }
        }

        public override void MoveLeft(int carXPos)
        {
            if (XPos > 0)
            {
                XPos--;
                WritePositionToConsole();
            }
        }

        protected override void WritePositionToConsole()
        {
            Console.WriteLine(String.Format("Sedan moved to x - {0} y - {1}", XPos, YPos));
        }
    }
}

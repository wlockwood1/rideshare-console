using System;

namespace TransportProj
{
    public class Sedan : Car
    {
        public Sedan(int xPos, int yPos, City city, Passenger passenger)
        {
			XPos = xPos;
			YPos = yPos;
			City = city;
			Passenger = passenger;
        }

		public override void MoveUp(int destYPos)
		{
			if (YPos < City.YMax)
			{
				YPos++;
				WritePositionToConsole();
			}
		}


		public override void MoveDown(int destYPos)
		{
			if (YPos > 0)
			{
				YPos--;
				WritePositionToConsole();
			}
		}

		public override void MoveRight(int destXPos)
		{
			if (XPos < City.XMax)
			{
				XPos++;
				WritePositionToConsole();
			}
		}

		public override void MoveLeft(int destXPos)
		{
			if (XPos > 0)
			{
				XPos--;
				WritePositionToConsole();
			}
		}

		public override void WritePositionToConsole()
		{
			Console.WriteLine(String.Format("Sedan moved to x - {0} y - {1}", XPos, YPos));
		}

    }
}

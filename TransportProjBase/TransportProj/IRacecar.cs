using System;
namespace TransportProj
{
	public abstract class IRacecar : ICar
	{
		public override void MoveUp(int destYPos)
		{
			if (YPos < City.YMax)
			{
				YPos = ((YPos + 1) == destYPos) ? YPos + 1 : YPos + 2;
				WritePositionToConsole();
			}
		}

		public override void MoveDown(int destYPos)
		{
			if (YPos > 0)
			{
				YPos = ((YPos - 1) == destYPos) ? YPos - 1 : YPos - 2;
				WritePositionToConsole();
			}
		}

		public override void MoveRight(int destXPos)
		{
			if (XPos < City.XMax)
			{
				XPos = ((XPos + 1) == destXPos) ? XPos + 1 : XPos + 2;
				WritePositionToConsole();
			}
		}

		public override void MoveLeft(int destXPos)
		{
			if (XPos > 0)
			{
				XPos = ((XPos - 1) == destXPos) ? XPos - 1 : XPos - 2;
				WritePositionToConsole();
			}
		}

		public override void WritePositionToConsole()
		{
			Console.WriteLine(String.Format("Racecar moved to x - {0} y - {1}", XPos, YPos));
		}
		
	}
}

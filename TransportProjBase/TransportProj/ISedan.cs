using System;
namespace TransportProj
{
	public abstract class ISedan : ICar
	{
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

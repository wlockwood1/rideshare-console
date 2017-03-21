namespace TransportProj 
{
    /// <summary>
    /// Represents a pair of (X, Y) coordinates that are inside the bounds of a City.
    /// </summary>
    public class Coordinate 
    {
        public int XPos { get; set; }
        public int YPos { get; set; }

        public Coordinate(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public override bool Equals(object obj) 
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Coordinate)obj);
        }

        private bool Equals(Coordinate other) 
        {
            return XPos == other.XPos && YPos == other.YPos;
        }

        public override int GetHashCode() 
        {
            unchecked 
            {
                return (XPos * 397) ^ YPos;
            }
        }
    }
}

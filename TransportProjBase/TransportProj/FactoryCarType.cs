public class FactoryCarType
{
    static public ICarType getCarTypeObj(string carType)
        {
            ICarType objCarType = null;

            if(carType.ToLower() == "sedan")
            {
                objCarType = new Sedan();
            } 
            else if (carType.ToLower() == "racecar")
            {
                objCarType = new Racecar();
            } 
            else {
                objCarType = new InvalidCarType();
            }
            return objCarType;
        }
}


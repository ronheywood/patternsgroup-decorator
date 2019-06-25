namespace StarBuzz.Beverages
{
    public class Decaf : Beverage
    {
        public override string GetDescription()
        {
            return
                "Decaf: All the taste, none of the twitches";
        }

        public override double Cost()
        {
            return 1.95;
        }
    }
}
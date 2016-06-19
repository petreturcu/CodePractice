namespace NinjectDI
{
    public interface ICaffeinated
    {
        int DrinkCount { get; set; }
        string Drink();
    }

    public class DietCoke : ICaffeinated
    {
        public int DrinkCount { get; set; }

        public string Drink()
        {
            DrinkCount++;
            return $"Sup {this.GetType().Name}!";
        }
    }

    public class PepsiMax : ICaffeinated
    {
        public int DrinkCount { get; set; }

        public string Drink()
        {
            DrinkCount++;
            return $"Sup {this.GetType().Name}!";
        }
    }
}
namespace NinjectDI
{
    public interface ICaffeinated
    {
        string Drink();
    }

    public class DietCoke : ICaffeinated
    {
        public string Drink()
        {
            return $"Sup {this.GetType().Name}!";
        }
    }

    public class PepsiMax : ICaffeinated
    {
        public string Drink()
        {
            return $"Sup {this.GetType().Name}!";
        }
    }
}
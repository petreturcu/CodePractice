namespace NinjectDI
{
    using System.Diagnostics.Eventing;

    public class Programmer
    {
        private readonly ICaffeinated drink;

        public Programmer(ICaffeinated drink)
        {
            this.drink = drink;
        }

        public string WriteCode()
        {
            return this.drink.Drink();
        }
    }
}
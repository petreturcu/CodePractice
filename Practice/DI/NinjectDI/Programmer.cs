namespace NinjectDI
{
    using System;

    public abstract class Programmer
    {
        private readonly ICaffeinated drink;
        private readonly IEditor editor;

        public Programmer(ICaffeinated drink, IEditor editor)
        {
            this.drink = drink;
            this.editor = editor;
        }

        public void WriteCode()
        {
            Console.WriteLine(this.drink.Drink());
            Console.WriteLine(this.editor.Code());
        }
    }

    public class JavaProgrammer : Programmer
    {
        public JavaProgrammer(ICaffeinated drink, IEditor editor) : base(drink, editor)
        {
        }
    }

    public class MicrosoftProgrammer : Programmer
    {
        public MicrosoftProgrammer(ICaffeinated drink, IEditor editor) : base(drink, editor)
        {
        }
    }
}
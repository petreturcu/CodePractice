namespace NinjectDI
{
    public interface IEditor
    {
        string Code();
    }

    public class VisualStudio : IEditor
    {
        public string Code()
        {
            return "Writing code in Visual Studio!";
        }
    }

    public class Eclipse : IEditor
    {
        public string Code()
        {
            return "Writing code in Eclipse!";
        }
    }
}
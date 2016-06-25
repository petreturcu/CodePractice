namespace StaticManualDI.Interfaces
{
    public interface IEmailProvider
    {
        string Description();
    }

    public class SmptEmailProvider : IEmailProvider
    {
        public string Description()
        {
            return $"Concrete {this.GetType().GetInterfaces()[0].Name} : {this.GetType().Name}";
        }
    }

    public class ImapEmailProvider : IEmailProvider
    {
        public string Description()
        {
            return $"Concrete {this.GetType().GetInterfaces()[0].Name} : {this.GetType().Name}";
        }
    }
}
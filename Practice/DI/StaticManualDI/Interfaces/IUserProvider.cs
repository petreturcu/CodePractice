namespace StaticManualDI.Interfaces
{
    public interface IUserProvider
    {
        string Description();
    }

    public class SqlServerUserProvider : IUserProvider
    {
        public string Description()
        {
            return $"Concrete {this.GetType().GetInterfaces()[0].Name} : {this.GetType().Name}";
        }
    }
}
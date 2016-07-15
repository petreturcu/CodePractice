namespace StaticManualDI.Interfaces
{
    public interface IDataProvider
    {
        string Description();
    }

    public class SqlServerDataProvider : IDataProvider
    {
        public string Description()
        {
            return $"Concrete {this.GetType().GetInterfaces()[0].Name} : {this.GetType().Name}";
        }
    }
}
namespace RepoFactoryDI
{
    public interface IUserRepository
    {
        string GetUserEmail(int userId);
    }

    public class UserRepository : IUserRepository
    {
        public string GetUserEmail(int userId)
        {
            return "cat@milk.com";
        }
    }



    public interface IMealRepository
    {
        string GetMeal(int forUserId);
    }

    public class MealRepository : IMealRepository
    {
        public string GetMeal(int forUserId)
        {
            return "Here's some milk.";
        }
    }
}
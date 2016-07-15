namespace RepoFactoryDI
{
    using System;

    public class UserRepositoryFactory
    {
        // to be set up at app start
        public static Func<IUserRepository> GetUserRepository = CreateDefaultUserRepository;

        private static IUserRepository CreateDefaultUserRepository()
        {
            throw new Exception("No repository implementation provided.");
        }
    }

    public class MealRepositoryFactory
    {
        // to be set up at app start
        public static Func<IMealRepository> GetMealRepository = CreateDefaultMealRepository;

        private static IMealRepository CreateDefaultMealRepository()
        {
            throw new Exception("No repository implementation provided.");
        }
    }
}
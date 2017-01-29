using System;

// derived from sample of http://jeffreypalermo.com/blog/the-onion-architecture-part-1/
namespace RepoFactoryDI
{
    class Program
    {
        static void Main(string[] args)
        {
            //app start
            UserRepositoryFactory.GetUserRepository = () => new UserRepository();
            MealRepositoryFactory.GetMealRepository = () => new MealRepository();


            // somewhere in middle/core project
            IUserRepository myUserRepo = UserRepositoryFactory.GetUserRepository();
            IMealRepository myMealRepo = MealRepositoryFactory.GetMealRepository();

            Console.WriteLine("Whats my email?\n" + myUserRepo.GetUserEmail(12345) + "\n");
            Console.WriteLine("I'd like something to drink.\n" + myMealRepo.GetMeal(12345));
        }
    }
}

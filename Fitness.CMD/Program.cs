
using FitnessTracker.BL.Controller;
using FitnessTracker.BL.Model;
using Fitness.CMD.Languages;
using System.Globalization;
using System.Resources;

class Program
{
    static void Main(string[] args)
    {
        var culture = new CultureInfo("en-us");
        var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

        Console.WriteLine("\t\t\t"+resourceManager.GetString("Hello",culture) + "\n\t\t\t"+resourceManager.GetString("Creator"));
        Console.WriteLine(resourceManager.GetString("EnterName",culture) +" - ");

        var name = Console.ReadLine();

        var userController = new UserController(name);
        var eatingController = new EatingController(userController.CurrentUser);
        if (userController.IsNewUser)
        {
            Console.Write("\n\nВведите пол - ");
            var gender = Console.ReadLine();

            var birthDate = ParseDateTime();
            var weight = ParseDouble("вес");

            var height = ParseDouble("рост");

            userController.SetNewUserData(gender, birthDate, weight, height);
        }

        Console.WriteLine(userController.CurrentUser);

        Console.WriteLine("Что вы хотите сделать?");
        Console.WriteLine("E - ввести прием пищи");
        var key = Console.ReadKey();
        Console.WriteLine();
        if (key.Key == ConsoleKey.E)
        {
            var foods = EnterEating();
            eatingController.Add(foods.Food,foods.Weight);

            foreach (var item in eatingController.Eating.Foods)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        
        }

    }

    private static (Food Food,double Weight) EnterEating()
    {
        Console.WriteLine("Enter name of product - ");
        var food = Console.ReadLine();

        var calories = ParseDouble("калорийность");
        var proteins = ParseDouble("протеины");
        var fats = ParseDouble("жиры");
        var carbs = ParseDouble("углеводы");

        var weight = ParseDouble("вес");
        var product = new Food(food,calories,proteins,fats,carbs);

        return (product, weight);


    }

    private static DateTime ParseDateTime()
    {
        DateTime birthDate;
        while (true)
        {
            Console.Write("\n\nВведите дату рождения (dd.MM.yyyy) - ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                break;
            }
            else
            {
                Console.WriteLine("Неверный формат даты рождения!");
            }
        }

        return birthDate;
    }

    private static double ParseDouble(string name)
    {
        while (true)
        {
            Console.Write($"\n\nВведите {name}: - ");
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                return value;
            }
            else
            {
                Console.WriteLine($"Неверный формат {name}!");
            }
        }
    }
}

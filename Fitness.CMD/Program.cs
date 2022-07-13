
using FitnessTracker.BL.Controller;
using FitnessTracker.BL.Model;
using Fitness.CMD.Languages;
using System.Globalization;
using System.Resources;

class Program
{

    static void Main(string[] args)
    {
        
        var culture = new CultureInfo("ru-ru");
        var resourceManager = new ResourceManager("Fitness.CMD.Languages.Messages", typeof(Program).Assembly);

        Console.WriteLine("\t\t\t"+resourceManager.GetString("Hello",culture) + "\n\t\t\t"+resourceManager.GetString("Creator"));
        

        var name = ParseString("имя");

        var userController = new UserController(name);
        var eatingController = new EatingController(userController.CurrentUser);
        var exerciseController = new ExerciseController(userController.CurrentUser);
        if (userController.IsNewUser)
        {
            var gender = ParseString("пол");
            var birthDate = ParseDateTime("дата рождения");
            var weight = ParseDouble("вес");
            var height = ParseDouble("рост");

            userController.SetNewUserData(gender, birthDate, weight, height);
        }

        Console.WriteLine(userController.CurrentUser);

        
        while (true)
        {
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи!");
            Console.WriteLine("F - ввести уражнения!");
            Console.WriteLine("D - посмотреть информацию о приемах пищи!");
            Console.WriteLine("C - посмотреть информацию о пользователи!");
            Console.WriteLine("Q - выход!");

            Console.WriteLine();
            var key = Console.ReadKey();
            Console.WriteLine();
            switch (key.Key)
            {
                case ConsoleKey.E:
                    var foods = EnterEating();
                    eatingController.Add(foods.Food, foods.Weight);

                    foreach (var item in eatingController.Eating.Foods)
                    {
                        Console.WriteLine($"\t{item.Key} - {item.Value}");
                    }
                    break;
                case ConsoleKey.F:
                    var exe = EnterExercise();
                    exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                    foreach (var item in exerciseController.Exercises)
                    {
                        Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                    }
                    break;
                case ConsoleKey.D:
                    int i = 1;
                    foreach (var item in eatingController.Foods)
                    {
                        
                        Console.WriteLine($"{i} - {item.Name}\n" +
                                          $"Протеинов - {item.Proteins}\n" +
                                          $"Жиров - {item.Fats}\n" +
                                          $"Углеводов - {item.Carbohydrats}\n" +
                                          $"Калориев - {item.Calories}\n");
                        i++;
                    }
                    break;
                case ConsoleKey.C:
                    foreach (var item in userController.Users)
                    {
                        Console.WriteLine($"{item.Id}: {item.Name}\n" +
                                          $"Возраст: {item.Age}\n" +
                                          $"Дата рождения: {item.BirthDate}\n" +
                                          $"Пол: {item.Gender}\n" +
                                          $"Рост: {item.Height}\n" +
                                          $"Вес: {item.Weight}\n");
                    }
                    break;

                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;

            }
        }

    }

    private static string ParseString(string Value)
    {
        while (true)
        {
            Console.Write("Введите " + Value + ": ");
            string  value = Console.ReadLine();
            if (!(String.IsNullOrWhiteSpace(value)))
            {
                return value;
            }
            else
            {
                Console.WriteLine("Введите коректное  "+Value);
            }
        }
    }

    private static (DateTime Begin,DateTime End,Activity Activity) EnterExercise()
    {
        Console.WriteLine("Введите название упражениня:");
        var name = Console.ReadLine();

        var energy = ParseDouble("расход енрегии в минуту!"); 

        var begin = ParseDateTime("начало упражнения");
        var end = ParseDateTime("конец упраженния");

        var activity = new Activity(name,energy);
        return (begin, end,activity);
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

    private static DateTime ParseDateTime(string value)
    {
        DateTime birthDate;
        while (true)
        {
            Console.Write($"\n\nВведите {value} (dd.MM.yyyy) - ");
            if (DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                break;
            }
            else
            {
                Console.WriteLine($"Неверный формат {value}!");
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

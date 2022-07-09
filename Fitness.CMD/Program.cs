﻿
using Fitness_Tracker.BL.Controller;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t\t\tПриложение Fitness\n\t\t\tСоздатель - Aiddam");
        Console.Write("\n\nВведите имя пользователя - ");

        var name = Console.ReadLine();

        var userController = new UserController(name);
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
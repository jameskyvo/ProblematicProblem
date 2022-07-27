using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program 
    { 
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
{
            const int WaitTime = 500;
            Random rng = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? true/false: \n");
            bool cont = bool.Parse(Console.ReadLine());
            if (cont == false)
            {
                Console.WriteLine("Goodbye!");
                return;
            }
            Console.Write("We are going to need your information first! What is your name? \n");
            string userName = Console.ReadLine();
            Console.Write("What is your age? \n");
            int userAge = int.Parse(Console.ReadLine());
            Console.Write("Would you like to see the current list of activities? true/false: \n");
            bool seeList = bool.Parse(Console.ReadLine());
    if (seeList)
    {
        foreach (string activity in activities)
        {
            Console.Write($"{activity} ");
            Thread.Sleep(WaitTime / 2);
        }
        Console.Write("\nWould you like to add any activities before we generate one? true/false:\n");
        bool addActivity = bool.Parse(Console.ReadLine());
        while (addActivity == true)
        {
            Console.Write("What would you like to add? \n");
            string userAddition = Console.ReadLine();
            activities.Add(userAddition);
            foreach (string activity in activities)
            {
                Console.Write($"{activity} ");
                Thread.Sleep(WaitTime / 2);
            }
            Console.WriteLine("\n Would you like to add more? true/false: \n");
            addActivity = bool.Parse(Console.ReadLine());
        }
    }
            bool con;
            do
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(WaitTime);
                }
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(WaitTime);
                }

                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Do you want to pick something else? true/false");
                    activities.Remove(randomActivity);
                    var random = rng.Next(activities.Count);
                    con = bool.Parse(Console.ReadLine());
                    continue;
                }
                Console.Write($"\n Ah got it! {userName}, your random activity is: {randomActivity}! Do you want to grab another activity? true/false: \n");
                con = bool.Parse(Console.ReadLine());

            } while (con == true);
}
    }
}
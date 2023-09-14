using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = false;
            string promtGen = Console.ReadLine();
            if (promtGen == "yes") { cont = true; }
            if (cont)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                int userAge = 0;
                bool numTrue = int.TryParse(Console.ReadLine(), out userAge);
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = false;
                string promtGen2 = Console.ReadLine();
                if (promtGen2 == "sure") { seeList = true; }
                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        //Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = false;
                    string promtGen3 = Console.ReadLine();
                    if (promtGen3 == "yes") { addToList = true; }
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            //Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        string promptGen4 = Console.ReadLine();
                        if (promptGen4 == "no") { addToList = false; }
                    }
                }

                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        //Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        //Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(0, activities.Count);
                    string randomActivity = activities[randomNumber];
                    Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    string promptGen5 = Console.ReadLine();
                    if (promptGen5 == "keep") { cont = false; }
                    bool tooYoung = false;
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {

                        int randomNum = rng.Next(activities.Count);
                        string randomAct = activities[randomNumber];
                        Console.WriteLine("Oh no! Looks like you are too young to do Wine Tasting");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        while (!tooYoung)
                        {
                            int randomNumber2 = rng.Next(0, activities.Count);
                            string randomActivity2 = activities[randomNumber2];
                            Console.WriteLine($"Ah got it! {userName}, your random activity is: {randomActivity2}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                            string promptGen7 = Console.ReadLine();
                            if (promptGen7 == "keep") { tooYoung = true; }
                        }
                    }
                    
                }
            }
        }
    }
}
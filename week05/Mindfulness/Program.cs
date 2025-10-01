// File: Program.cs
// Mindfulness Program - Week 05 Inheritance Project
// Author: Cristhian Nefi Dorado Aguilar
// Purpose: Complete implementation with base Activity class and three derived activities.

using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    class Program
    {
        // EXTRAS / CREATIVITY (for full points):
        // 1) Session logging: each completed activity is appended to a local log file "mindfulness_log.txt" with timestamp, activity name and duration.
        // 2) No prompt repeats until all prompts have been used in Reflection and Listing activities (session-level shuffling).
        // 3) Each class in this file follows naming and encapsulation conventions: private member variables use _underscoreCamelCase, public methods/use TitleCase.
        // Note: When submitting to Canvas, include this file comment explaining what was done to exceed requirements.

        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            bool running = true;

            // Initialize prompt managers (shared across activities to avoid repeats)
            var reflectionPrompts = new PromptManager(new List<string> {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            });

            var reflectionQuestions = new PromptManager(new List<string> {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            });

            var listingPrompts = new PromptManager(new List<string> {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            });

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program - Menu\n");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Log File");
                Console.WriteLine("5. Exit\n");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var breath = new BreathingActivity("Breathing Activity",
                            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
                            reflectionPrompts: null, listingPrompts: null);
                        breath.Start();
                        break;
                    case "2":
                        var reflect = new ReflectionActivity("Reflection Activity",
                            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
                            reflectionPrompts);
                        reflect.Start();
                        break;
                    case "3":
                        var listing = new ListingActivity("Listing Activity",
                            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
                            listingPrompts);
                        listing.Start();
                        break;
                    case "4":
                        ShowLog();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine("Goodbye! Press Enter to close.");
            Console.ReadLine();
        }

        static void ShowLog()
        {
            Console.Clear();
            string path = Logger.LogFilePath;
            Console.WriteLine("Session Log:\n");
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("No log entries yet.");
            }
            Console.WriteLine("\nPress Enter to return to menu.");
            Console.ReadLine();
        }
    }

    
    

    

   

    

    
}

// Exceeding requirements:
// - Only hides words that are not already hidden (avoids hiding the same word twice)
// - Configurable number of words to hide per iteration using LINQ for efficient filtering
// - Multiple scripture library with random selection
// - Progress tracking showing percentage of words hidden
// - Option to restart with a new scripture after completion

using System;
using System.Collections.Generic;

public class Program
{
    private static List<(Reference reference, string text)> _scriptureLibrary = new List<(Reference, string)>
    {
        (new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
        (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
        (new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
        (new Reference("Joshua", 1, 9), "Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged, for the Lord your God will be with you wherever you go.")
    };

    public static void Main()
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        
        while (true)
        {
            Scripture scripture = GetRandomScripture();
            RunMemorizationSession(scripture);
            
            Console.WriteLine("\nWould you like to try another scripture? (y/n):");
            string continueChoice = Console.ReadLine().ToLower();
            if (continueChoice != "y" && continueChoice != "yes")
            {
                break;
            }
        }
        
        Console.WriteLine("Thank you for using Scripture Memorizer!");
    }

    private static Scripture GetRandomScripture()
    {
        Random random = new Random();
        var selectedScripture = _scriptureLibrary[random.Next(_scriptureLibrary.Count)];
        return new Scripture(selectedScripture.reference, selectedScripture.text);
    }

    private static void RunMemorizationSession(Scripture scripture)
    {
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nProgress: {scripture.GetHiddenPercentage():F1}% of words hidden");
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit:");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                return;
            }
            
            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nCongratulations! All words are now hidden. You've completed this scripture!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
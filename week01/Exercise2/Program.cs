using System;

class Program
{
    static void Main(string[] args)
    {
    
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int gradePercentage = int.Parse(input);
        
       
        string letter = "";
        
       
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
       
        string sign = "";
        int lastDigit = gradePercentage % 10;
        
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        
        
       
        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }
        
        if (letter == "F")
        {
            sign = ""; 
        }
        
        
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        
       
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't worry, you'll do better next time!");
        }
    }
}
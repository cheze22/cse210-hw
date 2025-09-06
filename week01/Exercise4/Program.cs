using System;

class Program
{
    static void Main(string[] args)
    {
        
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
       
        int userInput = -1; 
        while (userInput != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            userInput = int.Parse(input);
            
         
            if (userInput != 0)
            {
                numbers.Add(userInput);
            }
        }
        
        
        
        
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");
        
        
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        
        
        int max = numbers[0]; 
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
        
       
        
        
        int smallestPositive = int.MaxValue; 
        bool foundPositive = false;
        
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
                foundPositive = true;
            }
        }
        
        if (foundPositive)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        
        
        numbers.Sort(); 
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
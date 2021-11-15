using System;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Input a number to convert: ");
        string input = Console.ReadLine();
        Console.WriteLine("Your inputted number is: $" + input);
        string result = currency.convertToString.parseInputToString(input);
        Console.WriteLine("Your result is: " + result);
    }
}
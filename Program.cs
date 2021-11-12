using System;
using System.IO;
namespace unleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = new Dictionary<integer, string>(){
{1, "one"},
{2,"two"},
{3, "three"},
{4,"four"},
{5,"five"},
{6,"six"},
{7,"seven"},
{8,"eight"},
{9,"nine"},
{10,"ten"},
            };
            Console.WriteLine("Input number to convert: ");
            string input = Console.ReadLine();
            Console.WriteLine("Your inputted number is " + input);
            try
            {
                //23.4 two three dot four  
                int number = Int32.Parse(input);
                for (int i = 0; i < input.Length; i++)
                {
                    Console.WriteLine(input[i]);
                }
            }
            // catch (IOException e)
            // {
            //     Console.WriteLine(e);
            // }
            catch (FormatException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Exiting..");
            }
        }
    }
}

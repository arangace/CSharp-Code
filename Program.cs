using System;
using System.IO;
using System.Collections.Generic;
namespace unleashed
{
    class Program
    {
        static void convert(Dictionary<string, string> integers, string input)
        {
            if (integers.ContainsKey(input))
            {
                Console.WriteLine(integers[input]);
            }
            Console.WriteLine(input);
            // Console.WriteLine(integers[number[i]]);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input number to convert: ");
            string input = Console.ReadLine();
            Console.WriteLine("Your inputted number is " + input);
            try
            {
                var integers = new Dictionary<string, string>(){
                {"1", "one"},
                {"2","two"},
                {"3", "three"},
                {"4","four"},
                {"5","five"},
                {"6","six"},
                {"7","seven"},
                {"8","eight"},
                {"9","nine"},
                {"10","ten"},

                };
                int number = Int32.Parse(input);

                for (int i = 0; i < input.Length; i++)
                {
                    // Console.WriteLine(input[i]);

                    convert(integers, input.Substring(i, 1));

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

using System;
using System.IO;
using System.Collections.Generic;
namespace unleashed
{
    class Program
    {
        static void convert(string input)
        {
            var integers = new Dictionary<string, string>(){
                {"00","zero"},
                {"01", "one"},
                {"02","two"},
                {"03", "three"},
                {"04","four"},
                {"05","five"},
                {"06","six"},
                {"07","seven"},
                {"08","eight"},
                {"09","nine"},
                {"10","ten"},
                {"11","eleven"},
                {"12","twleve"},
                {"13","thirteen"},
                {"14","fourteen"},
                {"15","fifteen"},
                {"16","sixteen"},
                {"17","seventeen"},
                {"18","eighteen"},
                {"19","nineteen"},
                };
            var largeIntegers = new Dictionary<string, string>(){
                {"2","twenty"},
                {"3", "thirty"},
                {"4","forty"},
                {"5", "fifty"},
                {"6","sixty"},
                {"7","seventy"},
                {"8","eighty"},
                {"9","ninety"},
                };
            //numbers onwards sort
            //checks against the dictionary for relative name
            //Checks if the value is within 0 to 19
            Console.WriteLine(input);
            Console.WriteLine(input.Substring(0, 1));
            if (integers.ContainsKey(input))
            {
                Console.WriteLine(integers[input]);
            }
            //else check if its value from 20 to 99
            else if (largeIntegers.ContainsKey(input.Substring(0, 1)))
            {
                Console.WriteLine("i hit it");
                Console.WriteLine(largeIntegers[input.Substring(0, 1)]);
            }
            // Console.WriteLine(integers[number[i]]);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input number to convert: ");
            string input = Console.ReadLine();
            Console.WriteLine("Your inputted number is " + input);
            try
            {
                //divide and separate units
                //if input number is between 0-9
                Console.WriteLine(input.Length);
                if (input.Length == 1)
                {
                    convert("0" + input);
                }
                else
                {
                    //else if the value is two digits but between 0 and 19
                    Console.WriteLine("substring" + input.Substring(input.Length - 2));
                    //Console.WriteLine("numbers is" + (input.Substring(input.Length - 1, input.Length - 2) + input.Substring(input.Length, input.Length - 1)));
                    convert(input.Substring(input.Length - 2));
                }

                for (int i = input.Length; i-- > 0;)
                {
                    // Console.WriteLine(input[i]);
                    //check if last two digits is between 0 and 19
                    Console.WriteLine(i);
                    if (i == input.Length - 1)
                    {



                    }
                    else
                    {

                    }
                    //parse it for digits between 20 to 99
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

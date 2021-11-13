using System;
using System.IO;
using System.Collections.Generic;
namespace unleashed
{
    class Program
    {
        static string convert(string input)
        {
            var integers = new Dictionary<string, string>(){
                {"0","zero "},
                {"1", "one "},
                {"2","two "},
                {"3", "three "},
                {"4","four "},
                {"5","five "},
                {"6","six "},
                {"7","seven "},
                {"8","eight "},
                {"9","nine "},
                {"10","ten "},
                {"11","eleven "},
                {"12","twelve "},
                {"13","thirteen "},
                {"14","fourteen "},
                {"15","fifteen "},
                {"16","sixteen "},
                {"17","seventeen "},
                {"18","eighteen "},
                {"19","nineteen "},
                };
            var largeIntegers = new Dictionary<string, string>(){
                {"2","twenty "},
                {"3", "thirty "},
                {"4","forty "},
                {"5", "fifty "},
                {"6","sixty "},
                {"7","seventy "},
                {"8","eighty "},
                {"9","ninety "},
                };
            string[] digitUnits = { "Hundred ", "Thousand ", "Million " };
            //numbers onwards sort
            //checks against the dictionary for relative name
            //Checks if the value is within 0 to 19
            Console.WriteLine(input);
            Console.WriteLine(input.Substring(0, 1));
            if (integers.ContainsKey(input))
            {
                Console.WriteLine(integers[input]);
                return integers[input];
            }
            //else check if its value from 20 to 99
            else if (largeIntegers.ContainsKey(input.Substring(0, 1)))
            {
                Console.WriteLine(largeIntegers[input.Substring(0, 1)]);
                Console.WriteLine(integers[input.Substring(1)]);
                return (largeIntegers[input.Substring(0, 1)] + integers[input.Substring(1)]);
                // if (largeIntegers.ContainsKey(input.Substring(1)))
                // {

                // }
            }
            else
            {
                return "-1";
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
                wordNumbers outputString = new wordNumbers();
                // outputString.concatString = "asd";
                // Console.WriteLine(outputString.concatString);
                //divide and separate units
                //if input number is between 0-9
                Console.WriteLine(input.IndexOf("."));
                //check if number is a decimal
                if (input.IndexOf(".") == -1)//if there is no decimal pointer
                {
                    if (input.Length == 1)
                    {

                        Console.WriteLine(convert(input));
                        outputString.concatString = convert(input);

                    }
                    else
                    {
                        //else if the value is two digits and but between 20 and 99 returns the tens value

                        Console.WriteLine(convert(input.Substring(input.Length - 2)));
                        outputString.concatString = convert(input.Substring(input.Length - 2));
                    }

                    for (int i = input.Length - 2; i-- > 0;)
                    {
                        //parsing the rest of the numbers
                        Console.WriteLine("parsing afterwards" + input[i]);
                    }
                }
                else//if there is a decimal
                {
                    //split number at decimal, parse both
                    Console.WriteLine("decimal entered..");
                    Console.WriteLine(input.Substring(0, input.IndexOf(".")));
                    Console.WriteLine(input.Substring(input.IndexOf(".")));
                    //getting cents value
                    outputString.concatString = "and " + convert(input.Substring(input.Length - 2)) + "cents";
                    Console.WriteLine(outputString.concatString);
                    //getting dollars value
                    for (int i = input.Length - 2; i-- > 0;)
                    {
                        //parsing the rest of the numbers
                        Console.WriteLine("parsing afterwards" + input[i]);
                    }
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

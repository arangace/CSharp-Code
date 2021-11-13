using System;
using System.Collections.Generic;
namespace currency
{
    public static class convertToString
    {
        private static string[] digitUnits = { "Hundred ", "Thousand ", "Million " };
        private static readonly Dictionary<string, string> integers
            = new Dictionary<string, string>{
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
                {"20","twenty "},
                {"30", "thirty "},
                {"40","forty "},
                {"50", "fifty "},
                {"60","sixty "},
                {"70","seventy "},
                {"80","eighty "},
                {"90","ninety "},
        };
        private static readonly Dictionary<string, string> midIntegers
         = new Dictionary<string, string>{
                {"20","twenty "},
                {"30", "thirty "},
                {"40","forty "},
                {"50", "fifty "},
                {"60","sixty "},
                {"70","seventy "},
                {"80","eighty "},
                {"90","ninety "},
    };
        private static string convertTwoDigits(string input)
        {
            //if value is between 0-9
            string convertedAmount = "";
            if (input.Substring(0, 1) == "0")
            {
                convertedAmount = integers[input.Substring(1)];
            }

            else
            {
                //if value between 10-19 or between 20-99
                convertedAmount = input.Substring(0, 1) == "1" ? integers[input] : midIntegers[input.Substring(0, 1) + "0"] + integers[input.Substring(1)];

            }
            return convertedAmount;
        }
        private static string convertDollars(string input)
        {
            //function takes in three numbers at a time
            //converts the first digit i.e 123 converts 1
            string dollars = "";
            string dollarsNum = input.Substring(0, input.Length - 2);
            Console.WriteLine(dollarsNum);
            for (int i = dollarsNum.Length; i >= 2; i -= 2)
            {
                if (i / 3 != 0)
                {

                }
                //passes the rest of the number minus the cents
                Console.WriteLine("parsing afterwards" + dollarsNum[i]);
                //convertDollars(input.Substring(0, input.Length - 2));

            }
            // Console.WriteLine("dollars converting.." + input);
            // Console.WriteLine(input);

            //dollars = integers[input.Substring(0, 1)] + convertTwoDigits(input.Substring(1));
            return dollars;
        }
        private static string convertCents(string input)
        {
            //method takes in two numbers at a time
            string cents = "";
            //Checks if the value is within 0 to 19
            Console.WriteLine("cents converting.." + input);
            Console.WriteLine(input.Substring(0, 1));
            cents = convertTwoDigits(input);
            return cents;

        }
        public static string parseInputToString(string input)
        {
            try
            {
                //assumes input is valid and cents will be 2dp if present.
                words.wordNumbers outputString = new words.wordNumbers();

                //divide and separate units
                //if input number is between 0-9
                Console.WriteLine(input.IndexOf("."));

                //check if number is a decimal
                if (input.IndexOf(".") == -1)//if there is no decimal pointer
                {
                    Console.WriteLine("no dec");
                    //getting dollars value
                    //if value is single digit
                    //if value has two digits
                    //if value is greater
                    for (int i = input.Length - 2; i - 2 > 0;)
                    {
                        //parsing the rest of the numbers
                        //input.length identifies the highest numerical unit

                        Console.WriteLine("parsing dollars.." + input[i]);
                        //convertDollars(input);
                    }
                    // if (input.Length == 1)
                    // {

                    //     Console.WriteLine(convert(input));
                    //     outputString.concatString = convert(input);

                    // }
                    // else
                    // {
                    //     //else if the value is two digits and but between 20 and 99 returns the tens value

                    //     Console.WriteLine(convert(input.Substring(input.Length - 2)));
                    //     outputString.concatString = convert(input.Substring(input.Length - 2));
                    // }

                    // for (int i = input.Length - 2; i-- > 0;)
                    // {
                    //     //parsing the rest of the numbers
                    //     Console.WriteLine("parsing afterwards" + input[i]);
                    // }
                }
                else//if there is a decimal
                {
                    //split number at decimal, parse both
                    Console.WriteLine("decimal entered..");

                    //parsing inputted decimal number
                    //remove the decimal point
                    Console.WriteLine(input.IndexOf("."));
                    Console.WriteLine(input.Length);
                    //if the inputted cents is not 2dp then we add a 0 i.e. 20.3 becomes 20.30
                    if (input.IndexOf(".") == input.Length - 2)
                    {
                        input = input + "0";
                    }
                    input = input.Replace(".", "");
                    //getting cents value
                    Console.WriteLine(input);
                    outputString.concatString = "and " + convertCents(input.Substring(input.Length - 2)) + "cents";
                    Console.WriteLine(outputString.concatString);
                    //getting dolalrs value
                    convertDollars(input);
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
            return "-1";
        }

    }
}

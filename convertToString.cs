using System;
using System.Collections.Generic;
namespace currency
{
    public static class convertToString
    {
        private static string[] digitUnits = { "", "thousand ", "million ", "billion ", "trillion ", "quadrillion " };
        private static readonly Dictionary<string, string> integers
            = new Dictionary<string, string>{
                {"0",""},
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
                convertedAmount = input.Substring(0, 1) == "1" ? integers[input] : integers[input.Substring(0, 1) + "0"] + integers[input.Substring(1)];

            }
            return convertedAmount;
        }
        private static string convertThreeDigits(string dollars, int unit, bool added)
        {
            string hundreds = "";
            if (added == false)
            {
                Console.WriteLine(added);
                //convert the hundred
                hundreds = integers[dollars.Substring(0, 1)];
                Console.WriteLine(hundreds);
            }
            //convert the tens
            string tens = convertTwoDigits(dollars.Substring(1, 2)) + digitUnits[(unit / 3) - 1];
            //string check
            if (dollars == "000")
            {
                return "";
            }
            if (added == true)
            {
                return tens;
            }
            if (dollars.Substring(1, 2) == "00")
            {

                return hundreds + "hundred ";
            }
            else
            {
                return hundreds + "hundred and " + tens;
            }

        }
        private static string convertDollars(string dollarsNum)
        {
            //function takes in three numbers at a time
            //converts the first digit i.e 123 converts 1

            string dollars = "";
            int i = 0;
            bool added = false;
            int unitLength = 0;
            Console.WriteLine("dollarsnum.." + dollarsNum);
            //if number is multiple of 3 digits
            if ((3 - dollarsNum.Length % 3) == 1)
            {
                dollarsNum = "0" + dollarsNum;
                added = true;
            }
            else if ((3 - dollarsNum.Length % 3) == 2)
            {
                dollarsNum = "00" + dollarsNum;
                added = true;
            }
            unitLength = dollarsNum.Length;
            for (i = 0; i < dollarsNum.Length; i += 3)
            {

                //runs normally

                dollars += convertThreeDigits(dollarsNum.Substring(i, 3), unitLength, added);
                Console.WriteLine("current dollars" + dollars);
                added = false;
                unitLength -= 3;

            }
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
        private static string hasDecimal(string input)
        {
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
            //getting dollars value
            string dollar = convertDollars(input.Substring(0, input.Length - 2)) + "dollars ";
            //getting cents value
            string cents = "and " + convertCents(input.Substring(input.Length - 2)) + "cents";

            return dollar + cents;

        }
        private static string noDecimal(string input)
        {

            //getting dolalrs value
            string dollar = convertDollars(input) + "dollars ";
            Console.WriteLine("output dolalrs is" + dollar);
            return dollar;

        }
        public static string parseInputToString(string input)
        {
            try
            {
                //assumes input is valid and cents will be 1-2dp if present.
                words.wordNumbers outputString = new words.wordNumbers();
                int hasZeros = Int32.Parse(input.Replace(".", ""));

                if (hasZeros == 0)
                {
                    Console.WriteLine("null input" + hasZeros);
                    return "-1";
                }
                else if (input.Length - input.IndexOf(".") > 3)
                {
                    Console.WriteLine("incorrect cents input");
                    return "-1";
                }
                //divide and separate units
                //if input number is between 0-9
                string result = "No result";
                //check if number is a decimal

                if (input.IndexOf(".") == -1)//if there is no decimal pointer
                {
                    Console.WriteLine("no dec");
                    result = noDecimal(input);
                    outputString.concatString = result;

                }
                else//if there is a decimal
                {
                    //split number at decimal, parse both
                    Console.WriteLine("decimal entered..");
                    result = hasDecimal(input);
                    outputString.concatString = result;

                }


                Console.WriteLine(outputString.concatString);


            }
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
